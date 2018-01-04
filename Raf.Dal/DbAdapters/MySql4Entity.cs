using System;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;
namespace Raf.Dal
{
	public class MySql4Entity : BusinessEntity
	{
		public MySql4Entity()
		{
		}
		override internal DynamicQuery CreateDynamicQuery(BusinessEntity entity)
		{
			return new MySql4DynamicQuery(entity);
		}
		override internal IDataParameter CreateIDataParameter(string name, object value)
		{
			MySqlParameter p = new MySqlParameter();
			p.ParameterName = name;
			p.Value = value;
			return p;
		}
		override internal IDataParameter CreateIDataParameter()
		{
			return new MySqlParameter();
		}
		override internal IDbCommand CreateIDbCommand()
		{
			return new MySqlCommand();
		}
		override internal IDbDataAdapter CreateIDbDataAdapter()
		{
			return new MySqlDataAdapter();
		}
		override internal IDbConnection CreateIDbConnection()
		{
			return new MySqlConnection();
		}
		override internal DbDataAdapter ConvertIDbDataAdapter(IDbDataAdapter dataAdapter)
		{
			return (dataAdapter as MySqlDataAdapter) as DbDataAdapter;
		}
		override public void AddNew()
		{
			if(this.DataTable == null)
			{
				this.LoadFromSql("SELECT * FROM `" +  QuerySource + "` WHERE 1=0", null, CommandType.Text);
			}
			DataRow newRow = this.DataTable.NewRow();
			this.DataTable.Rows.Add(newRow);
			this.DataRow = newRow;
		}
		override internal IDbCommand _LoadFromRawSql(string rawSql, params object[] parameters)
		{
			int i = 0;
			string token  = "";
			string sIndex = "";
			string param  = "";
			MySqlCommand cmd = new MySqlCommand();
			foreach(object o in parameters)
			{
				sIndex = i.ToString();
				token = '{' + sIndex + '}';
				param = "?p" + sIndex;
				rawSql = rawSql.Replace(token, param);
				MySqlParameter p = new MySqlParameter(param, o);
				cmd.Parameters.Add(p);
				i++;
			}
			cmd.CommandText = rawSql;
			return cmd;
		}
		#region LastIdentity Logic
		public virtual string GetAutoKeyColumns()
		{
			return "";
		}
		override protected void HookupRowUpdateEvents(DbDataAdapter adapter)
		{
			if(this.GetAutoKeyColumns().Length > 0)
			{
				MySqlDataAdapter da = adapter as MySqlDataAdapter;
				da.RowUpdated += new MySqlRowUpdatedEventHandler(OnRowUpdated);
			}
		}
		protected void OnRowUpdated(object sender, MySqlRowUpdatedEventArgs e)
		{
			try
			{
				if(e.Status == UpdateStatus.Continue && e.StatementType == StatementType.Insert)
				{
					TransactionMgr txMgr = TransactionMgr.ThreadTransactionMgr();
					string identityCol = this.GetAutoKeyColumns();
					MySqlCommand cmd = new MySqlCommand();
					cmd.CommandText = "SELECT LAST_INSERT_ID();";
					txMgr.Enlist(cmd, this);
					object o = cmd.ExecuteScalar();
					txMgr.DeEnlist(cmd, this);
					if(o != null)
					{
						e.Row[identityCol] = o;
					}
					e.Row.AcceptChanges();
				}
			}
			catch {}
		}
		#endregion
	}
}
