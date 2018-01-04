using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
namespace Raf.Dal
{
	public class OleDbEntity : BusinessEntity
	{
		public OleDbEntity()
		{
		}
		override internal DynamicQuery CreateDynamicQuery(BusinessEntity entity)
		{
			return new OleDbDynamicQuery(entity);
		}
		override internal IDataParameter CreateIDataParameter(string name, object value)
		{
			OleDbParameter p = new OleDbParameter();
			p.ParameterName = name;
			p.Value = value;
			return p;
		}
		override internal IDataParameter CreateIDataParameter()
		{
			return new OleDbParameter();
		}
		override internal IDbCommand CreateIDbCommand()
		{
			return new OleDbCommand();
		}
		override internal IDbDataAdapter CreateIDbDataAdapter()
		{
			return new OleDbDataAdapter();
		}
		override internal IDbConnection CreateIDbConnection()
		{
			return new OleDbConnection();
		}
		override internal DbDataAdapter ConvertIDbDataAdapter(IDbDataAdapter dataAdapter)
		{
			return (dataAdapter as OleDbDataAdapter) as DbDataAdapter;
		}
		#region @@IDENTITY Logic
		public virtual string GetAutoKeyColumn()
		{
			return "";
		}
		override protected void HookupRowUpdateEvents(DbDataAdapter adapter)
		{
			if(this.GetAutoKeyColumn().Length > 0)
			{
				OleDbDataAdapter da = adapter as OleDbDataAdapter;
				da.RowUpdated += new OleDbRowUpdatedEventHandler(OnRowUpdated);
			}
		}
		protected void OnRowUpdated(object sender, OleDbRowUpdatedEventArgs e)
		{
			try
			{
				if(e.Status == UpdateStatus.Continue && e.StatementType == StatementType.Insert)
				{
					TransactionMgr txMgr = TransactionMgr.ThreadTransactionMgr();
					OleDbCommand cmd = new OleDbCommand("SELECT @@IDENTITY");
					txMgr.Enlist(cmd, this);
					object o = cmd.ExecuteScalar();
					txMgr.DeEnlist(cmd, this);
					if(o != null)
					{
						e.Row[this.GetAutoKeyColumn()] = o;
						e.Row.AcceptChanges();
					}
				}
			}
			catch {}
		}
		#endregion
		override internal IDbCommand _LoadFromRawSql(string rawSql, params object[] parameters)
		{
			int i = 0;
			string token  = "";
			string sIndex = "";
			string param  = "";
			OleDbCommand cmd = new OleDbCommand();
			foreach(object o in parameters)
			{
				sIndex = i.ToString();
				token = '{' + sIndex + '}';
				param = "@p" + sIndex;
				rawSql = rawSql.Replace(token, param);
				OleDbParameter p = new OleDbParameter(param, o);
				cmd.Parameters.Add(p);
				i++;
			}
			cmd.CommandText = rawSql;
			return cmd;
		}
	}
}
