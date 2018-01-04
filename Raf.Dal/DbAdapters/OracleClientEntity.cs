using System;
using System.Data;
using System.Data.Common;
using System.Data.OracleClient;
namespace Raf.Dal
{
	public class OracleClientEntity : BusinessEntity
	{
		public OracleClientEntity()
		{
		}
		override internal DynamicQuery CreateDynamicQuery(BusinessEntity entity)
		{
			return new OracleClientDynamicQuery(entity);
		}
		override internal IDataParameter CreateIDataParameter(string name, object value)
		{
			OracleParameter p = new OracleParameter();
			p.ParameterName = name;
			p.Value = value;
			return p;
		}
		override internal IDataParameter CreateIDataParameter()
		{
			return new OracleParameter();
		}
		override internal IDbCommand CreateIDbCommand()
		{
			return new OracleCommand();
		}
		override internal IDbDataAdapter CreateIDbDataAdapter()
		{
			return new OracleDataAdapter();
		}
		override internal IDbConnection CreateIDbConnection()
		{
			return new OracleConnection();
		}
		override internal DbDataAdapter ConvertIDbDataAdapter(IDbDataAdapter dataAdapter)
		{
			return (dataAdapter as OracleDataAdapter) as DbDataAdapter;
		}
		override public void AddNew()
		{
			if(this.DataTable == null)
			{
				this.LoadFromSql("SELECT * FROM " +  QuerySource + " WHERE rownum < 1", null, CommandType.Text);
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
			OracleCommand cmd = new OracleCommand();
			foreach(object o in parameters)
			{
				sIndex = i.ToString();
				token = '{' + sIndex + '}';
				param = ":p" + sIndex;
				rawSql = rawSql.Replace(token, param);
				OracleParameter p = new OracleParameter(param, o);
				cmd.Parameters.Add(p);
				i++;
			}
			cmd.CommandText = rawSql;
			return cmd;
		}
	}
}