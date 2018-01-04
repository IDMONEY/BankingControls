using System;
using System.Data;
using System.Data.Common;
using Npgsql;
namespace Raf.Dal
{
	public class PostgreSqlEntity : BusinessEntity
	{
		public PostgreSqlEntity()
		{
		}
		override internal DynamicQuery CreateDynamicQuery(BusinessEntity entity)
		{
			return new PostgreSqlDynamicQuery(entity);
		}
		override internal IDataParameter CreateIDataParameter(string name, object value)
		{
			NpgsqlParameter p = new NpgsqlParameter();
			p.ParameterName = name;
			p.Value = value;
			return p;
		}
		override internal IDataParameter CreateIDataParameter()
		{
			return new NpgsqlParameter();
		}
		override internal IDbCommand CreateIDbCommand()
		{
			return new NpgsqlCommand();
		}
		override internal IDbDataAdapter CreateIDbDataAdapter()
		{
			return new NpgsqlDataAdapter();
		}
		override internal IDbConnection CreateIDbConnection()
		{
			return new NpgsqlConnection();
		}
		override internal DbDataAdapter ConvertIDbDataAdapter(IDbDataAdapter dataAdapter)
		{
			return (dataAdapter as NpgsqlDataAdapter) as DbDataAdapter;
		}
		override public void AddNew()
		{
			if(this.DataTable == null)
			{
				this.LoadFromSql("SELECT * FROM \"" +  QuerySource + "\" WHERE 1=0", null, CommandType.Text);
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
			NpgsqlCommand cmd = new NpgsqlCommand();
			foreach(object o in parameters)
			{
				sIndex = i.ToString();
				token = '{' + sIndex + '}';
				param = "@p" + sIndex;
				rawSql = rawSql.Replace(token, param);
				NpgsqlParameter p = new NpgsqlParameter(param, o);
				cmd.Parameters.Add(p);
				i++;
			}
			cmd.CommandText = rawSql;
			return cmd;
		}
	}
}
