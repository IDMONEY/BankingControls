using System;
using System.Data;
using System.Configuration;
using System.Threading;
using System.Diagnostics;
using System.Collections;

namespace Raf.Dal
{
	public class TransactionMgr
	{
		protected TransactionMgr()
		{

		}

		public int NestingCount
		{
			get
			{
				return this.txCount;
			}
		}

		public bool HasBeenRolledBack
		{
			get
			{
				return hasRolledBack;
			}
		}

		public void BeginTransaction()
		{
			if( hasRolledBack) throw new Exception("Transaction Rolledback");

			txCount = txCount + 1;
		}

		public void CommitTransaction()
		{
			if(hasRolledBack) throw new Exception("Transaction Rolledback");

			txCount = txCount - 1;

			if(txCount == 0)
			{
				foreach(Transaction tx in this.transactions.Values)
				{
                    tx.sqlTx.Commit();
                    tx.Dispose();
				}

				this.transactions.Clear();

				if(this.objectsInTransaction != null)
				{
					try
					{
						foreach(BusinessEntity entity in this.objectsInTransaction)
						{
							entity.AcceptChanges();
						}
					} 
					catch {}

					this.objectsInTransaction = null;
				}
			}
		}

		public void RollbackTransaction()
		{
			if(false == hasRolledBack && txCount > 0)
			{
				foreach(Transaction tx in this.transactions.Values)
				{
					tx.sqlTx.Rollback();
                    tx.Dispose();
				}

                this.transactions.Clear();
                this.txCount = 0;
				this.objectsInTransaction = null;
			}
		}


		public void Enlist(IDbCommand cmd, BusinessEntity entity)
		{
			if(txCount == 0 || entity._notRecommendedConnection != null)
			{
				
				cmd.Connection = CreateSqlConnection(entity);
			}
			else
			{
				string connStr = entity._config;
				if(entity._raw != "") connStr = entity._raw;

				Transaction tx = this.transactions[connStr] as Transaction;

				if(tx == null)
				{
                    IDbConnection sqlConn = CreateSqlConnection(entity);
                    
                    tx = new Transaction();
					tx.sqlConnection = sqlConn;

					if(_isolationLevel != IsolationLevel.Unspecified)
					{
						tx.sqlTx = sqlConn.BeginTransaction(_isolationLevel);
					}
					else
					{
						tx.sqlTx = sqlConn.BeginTransaction();
					}
					this.transactions[connStr] = tx;
				}

                cmd.Connection = tx.sqlConnection;
				cmd.Transaction = tx.sqlTx;
			}
		}

		public void DeEnlist(IDbCommand cmd, BusinessEntity entity)
		{
			if(entity._notRecommendedConnection != null)
			{
				cmd.Connection = null;
			}
			else
			{
				if(txCount == 0)
				{
					cmd.Connection.Dispose();
				}
			}
		}

		
		
		
		
		internal void AddBusinessEntity(BusinessEntity entity)
		{
			if(this.objectsInTransaction == null)
			{
				this.objectsInTransaction = new ArrayList();
			}

			this.objectsInTransaction.Add(entity);
		}

		private IDbConnection CreateSqlConnection(BusinessEntity entity)
		{
			IDbConnection cn;

			if(entity._notRecommendedConnection != null)
			{
				
				cn = entity._notRecommendedConnection;
			}
			else
			{
				cn = entity.CreateIDbConnection();

				if(entity._raw != "")
					cn.ConnectionString = entity._raw;
				else
					cn.ConnectionString = ConfigurationManager.AppSettings[entity._config];
                    cn.ConnectionString = ConfigurationSettings.AppSettings[entity._config];

				cn.Open();
			}

			return cn;
		}

		
		
		private class Transaction : IDisposable
        {
            public IDbTransaction sqlTx = null;
            public IDbConnection sqlConnection = null;

            #region IDisposable Members
            public void Dispose()
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }

                if (sqlTx != null)
                {
                    sqlTx.Dispose();
                }
            }
            #endregion
        }

        private Hashtable transactions = new Hashtable();
		private int txCount = 0;
		private bool hasRolledBack  = false;

		
		internal ArrayList objectsInTransaction = null;

		#region "static"
		public static TransactionMgr ThreadTransactionMgr()
		{
			TransactionMgr txMgr = null;

			object obj = Thread.GetData(txMgrSlot);

			if(obj != null)
			{
				txMgr = (TransactionMgr)obj;
			}
			else
			{
				txMgr = new TransactionMgr();
				Thread.SetData(txMgrSlot, txMgr);
			}

			return txMgr;
		}

		public static void ThreadTransactionMgrReset()
		{
			TransactionMgr txMgr = TransactionMgr.ThreadTransactionMgr();

			try
			{
				if(txMgr.txCount > 0 && txMgr.hasRolledBack == false)
				{
					txMgr.RollbackTransaction();
				}
			}
			catch {}

			Thread.SetData(txMgrSlot, null);
		}

		public static IsolationLevel IsolationLevel
		{
			get
			{
				return _isolationLevel;
			}

			set
			{
				_isolationLevel = value;
			}
		}

        private static IsolationLevel _isolationLevel = IsolationLevel.Unspecified;
		private static LocalDataStoreSlot txMgrSlot = Thread.AllocateDataSlot();
		#endregion

	}
}
