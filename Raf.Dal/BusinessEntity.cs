using System;
using System.IO;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Specialized;
using System.Globalization;
using System.Xml.Serialization;namespace Raf.Dal
{
	abstract public class BusinessEntity
	{
		abstract internal DynamicQuery   CreateDynamicQuery(BusinessEntity entity);
		abstract internal IDbCommand     CreateIDbCommand();
		abstract internal IDbDataAdapter CreateIDbDataAdapter();
		abstract internal IDbConnection  CreateIDbConnection();
		abstract internal IDataParameter CreateIDataParameter(string name, object value);
		abstract internal IDataParameter CreateIDataParameter();
		abstract internal DbDataAdapter  ConvertIDbDataAdapter(IDbDataAdapter dataAdapter);
		virtual  internal IDbCommand _LoadFromRawSql(string rawSql, params object[] parameters)
		{
			return null;
		}
		public string StringFormat = "MM/dd/yyyy";
		virtual public string QuerySource
		{
			get { return SchemaTableView + _querySource; }
			set { _querySource = value; }
		}
		virtual public string MappingName
		{
			get { return _mappingName; }
			set { _mappingName = value; }
		}
		virtual public string SchemaGlobal
		{
			get { return _schemaGlobal; }
			set
			{
				_schemaGlobal = value;
				SchemaTableView = value;
				SchemaStoredProcedure = value;
			}
		}
		virtual public string SchemaTableView
		{
			get { return _tableViewSchema; }
			set { _tableViewSchema = value;}
		}
		virtual public string SchemaStoredProcedure
		{
			get { return _storedProcSchema; }
			set { _storedProcSchema = value;}
		}
		virtual protected IDbCommand GetInsertCommand()
		{
			return null;
		}
		virtual protected IDbCommand GetUpdateCommand()
		{
			return null;
		}
		virtual protected IDbCommand GetDeleteCommand()
		{
			return null;
		}
		virtual protected internal void OnQueryLoad(string conjuction)
		{		}
		virtual public IDbConnection NotRecommendedConnection
		{
			get
			{
				return this._notRecommendedConnection;
			}
			set
			{
				this._notRecommendedConnection = value;
			}
		}
		virtual public string ConnectionString
		{
			get
			{
				return _raw;
			}
			set
			{
				_raw = value;
			}
		}
		virtual public string ConnectionStringConfig
		{
			get
			{
				return _config;
			}
			set
			{
				_config = value;
			}
		}
		static public string DefaultConnectionStringConfig
		{
			get
			{
				return BusinessEntity._defaultConfig;
			}
			set
			{
				BusinessEntity._defaultConfig = value;
			}
		}
		public string Filter
		{
			get
			{
				string _filter = "";				if(_dataTable != null)
				{
					_filter = _dataTable.DefaultView.RowFilter;
				}				return _filter;
			}			set
			{
				if(_dataTable != null)
				{
					_dataTable.DefaultView.RowFilter = value;
					Rewind();
				}
			}
		}
		public string Sort
		{
			get
			{
				string _sort = "";				if(_dataTable != null)
				{
					_sort = _dataTable.DefaultView.Sort;
				}				return _sort;
			}			set
			{
				if(_dataTable != null)
				{
					_dataTable.DefaultView.Sort = value;
					Rewind();
				}
			}
		}
		public DataColumn AddColumn(string name, System.Type dataType)
		{
			DataColumn dc = null;			if(_dataTable != null)
			{
				dc = new DataColumn(name, dataType);
				_dataTable.Columns.Add(dc);
			}			return dc;
		}
		public DataRowState RowState()
		{
			if(_dataTable != null && _dataRow != null)
				return _dataRow.RowState;
			else
				return DataRowState.Detached;
		}
		public int RowCount
		{
			get
			{
				int count = 0;				if(_dataTable != null)
				{
					count = _dataTable.DefaultView.Count;
				}				return count;
			}
		}
		public void Rewind()
		{
			_dataRow = null;
			_enumerator = null;			if(_dataTable != null)
			{
				if(_dataTable.DefaultView.Count > 0)
				{
					_enumerator = _dataTable.DefaultView.GetEnumerator();
					_enumerator.MoveNext();
					DataRowView rowView  = (DataRowView)_enumerator.Current;
					_dataRow = rowView.Row;
					_EOF = false;
				}
				else
				{
					_EOF = true;
				}
			}
			else
			{
				_EOF = true;
			}
		}
		public bool MoveNext()
		{
			bool moved = false;			if( _enumerator != null && _enumerator.MoveNext())
			{
				DataRowView rowView  = (DataRowView)_enumerator.Current;
				_dataRow = rowView.Row;
				moved = true;
			}
			else
			{
				_EOF = true;
			}			return moved;
		}
		public bool EOF
		{
			get
			{
				return _EOF;
			}
		}
		public virtual void FlushData()
		{
			_dataRow = null;
			_dataTable = null;
			_enumerator = null;
			_query = null;
			_canSave = true;
			_EOF = true;
		}
		public DataView DefaultView
		{
			get
			{
				if(_dataTable != null)
					return _dataTable.DefaultView;
				else
					return null;
			}
		}
		internal protected DataTable DataTable
		{
			get
			{
				return _dataTable;
			}			set
			{
				_dataTable = value;
				_dataRow = null;				if(_dataTable != null)
				{
					Rewind();
				}
			}
		}
		internal protected DataRow DataRow
		{
			get
			{
				return _dataRow;
			}			set
			{
				_dataRow = value;
			}
		}		
        #region ToXml / FromXml
		virtual public string Serialize()
		{
			DataSet dataSet = new DataSet();
			dataSet.Tables.Add( _dataTable );
			StringWriter writer = new StringWriter();
			XmlSerializer ser = new XmlSerializer(typeof(DataSet));
			ser.Serialize(writer, dataSet);
			dataSet.Tables.Clear();
			return writer.ToString();
		}
		virtual public void Deserialize(string xml)
		{
			DataSet dataSet = new DataSet();
			StringReader reader = new StringReader(xml);
			XmlSerializer ser = new XmlSerializer(typeof(DataSet));
			dataSet = (DataSet)ser.Deserialize(reader);
			this.DataTable =  dataSet.Tables[0];
			dataSet.Tables.Clear();
		}
		virtual public string ToXml()
		{
			DataSet dataSet = new DataSet();
			dataSet.Tables.Add( _dataTable );
			StringWriter writer = new StringWriter();
			dataSet.WriteXml(writer);
			dataSet.Tables.Clear();
			return writer.ToString();
		}
		virtual public string ToXml(XmlWriteMode mode)
		{
			DataSet dataSet = new DataSet();
			dataSet.Tables.Add( _dataTable );
			StringWriter writer = new StringWriter();
			dataSet.WriteXml(writer, mode);
			dataSet.Tables.Clear();
			return writer.ToString();
		}
		virtual public void FromXml(string xml)
		{
			DataSet dataSet = new DataSet();
			StringReader reader = new StringReader(xml);
			dataSet.ReadXml(reader);
			this.DataTable =  dataSet.Tables[0];
			dataSet.Tables.Clear();
		}
		virtual public void FromXml(string xml, XmlReadMode mode)
		{
			DataSet dataSet = new DataSet();
			StringReader reader = new StringReader(xml);
			dataSet.ReadXml(reader, mode);
			this.DataTable =  dataSet.Tables[0];
			dataSet.Tables.Clear();
		}
		protected bool LoadFromSql(string sp)
		{
			return this.LoadFromSql(sp, null, CommandType.StoredProcedure);
		}
		protected bool LoadFromSql(string sp, ListDictionary Parameters)
		{
			return this.LoadFromSql(sp, Parameters, CommandType.StoredProcedure);
		}
		protected bool LoadFromSql(string sp, ListDictionary Parameters, CommandType commandType)
		{
			DataTable dataTable = null;
			bool loaded  = false;			try
			{
				dataTable = new DataTable(this.MappingName);				IDbCommand cmd = this.CreateIDbCommand();
				cmd.CommandText = sp;
				cmd.CommandType = commandType;				IDataParameter p;				if( Parameters != null)
				{
					foreach(DictionaryEntry param in Parameters)
					{
						p = param.Key as IDataParameter;						if(null == p)
						{
							p = this.CreateIDataParameter((string)param.Key, param.Value);
						}
						else
						{
							p.Value = param.Value;
						}						cmd.Parameters.Add(p);
					}
				}				IDbDataAdapter da = this.CreateIDbDataAdapter();				da.SelectCommand = cmd;				TransactionMgr txMgr = TransactionMgr.ThreadTransactionMgr();				txMgr.Enlist(cmd, this);
				DbDataAdapter dba = ConvertIDbDataAdapter(da);
				dba.Fill(dataTable);
				txMgr.DeEnlist(cmd, this);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				this.DataTable = dataTable;
				loaded = (this.RowCount > 0);
			}			return loaded;
		}
		protected bool LoadFromRawSql(string rawSql, params object[] parameters)
		{
			bool loaded  = false;
			DataTable dt = null;			try
			{
				IDbCommand cmd  = _LoadFromRawSql(rawSql, parameters);				IDbDataAdapter da = this.CreateIDbDataAdapter();
				da.SelectCommand = cmd;				TransactionMgr txMgr = TransactionMgr.ThreadTransactionMgr();				dt = new DataTable(this.MappingName);				txMgr.Enlist(cmd, this);
				DbDataAdapter dbDataAdapter = this.ConvertIDbDataAdapter(da);
				dbDataAdapter.Fill(dt);
				txMgr.DeEnlist(cmd, this);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			finally
			{
				this.DataTable = dt;
				loaded = (dt.Rows.Count > 0);
			}			return loaded;
		}
		protected int LoadFromSqlNoExec(string sp)
		{
			return this.LoadFromSqlNoExec(sp, null, CommandType.StoredProcedure, -1);
		}
		protected int LoadFromSqlNoExec(string sp, ListDictionary Parameters)
		{
			return this.LoadFromSqlNoExec(sp, Parameters, CommandType.StoredProcedure, -1);
		}
		protected int LoadFromSqlNoExec(string sp,
			ListDictionary Parameters,
			CommandType commandType,
			int commandTimeout)
		{
			int retValue = 0;			try
			{
				IDbCommand cmd = this.CreateIDbCommand();
				cmd.CommandText = sp;
				cmd.CommandType = commandType;				if(commandTimeout > 0)
				{
					cmd.CommandTimeout = commandTimeout;
				}				IDataParameter p;				if( Parameters != null)
				{
					foreach(DictionaryEntry param in Parameters)
					{
						p = param.Key as IDataParameter;						if(null == p)
						{
							p = this.CreateIDataParameter((string)param.Key, param.Value);
						}
						else
						{
							p.Value = param.Value;
						}						cmd.Parameters.Add(p);
					}
				}				TransactionMgr txMgr = TransactionMgr.ThreadTransactionMgr();				txMgr.Enlist(cmd, this);
				retValue = cmd.ExecuteNonQuery();
				txMgr.DeEnlist(cmd, this);
			}
			catch(Exception ex)
			{
				throw ex;
			}			return retValue;
		}
		protected object LoadFromSqlScalar(string sp)
		{
			return this.LoadFromSqlScalar(sp, null, CommandType.StoredProcedure, -1);
		}
		protected object LoadFromSqlScalar(string sp, ListDictionary Parameters)
		{
			return this.LoadFromSqlScalar(sp, Parameters, CommandType.StoredProcedure, -1);
		}
		protected object LoadFromSqlScalar(string sp,
			ListDictionary Parameters,
			CommandType commandType,
			int commandTimeout)
		{
			object retValue = 0;			try
			{
				IDbCommand cmd = this.CreateIDbCommand();
				cmd.CommandText = sp;
				cmd.CommandType = commandType;				if(commandTimeout > 0)
				{
					cmd.CommandTimeout = commandTimeout;
				}				IDataParameter p;				if( Parameters != null)
				{
					foreach(DictionaryEntry param in Parameters)
					{
						p = param.Key as IDataParameter;						if(null == p)
						{
							p = this.CreateIDataParameter((string)param.Key, param.Value);
						}
						else
						{
							p.Value = param.Value;
						}						cmd.Parameters.Add(p);
					}
				}				TransactionMgr txMgr = TransactionMgr.ThreadTransactionMgr();				txMgr.Enlist(cmd, this);
				retValue = cmd.ExecuteScalar();
				txMgr.DeEnlist(cmd, this);
			}
			catch(Exception ex)
			{
				throw ex;
			}			return retValue;
		}
		protected IDataReader LoadFromSqlReader(string sp)
		{
			return this.LoadFromSqlReader(sp, null, CommandType.StoredProcedure);
		}
		protected IDataReader LoadFromSqlReader(string sp, ListDictionary Parameters)
		{
			return this.LoadFromSqlReader(sp, Parameters, CommandType.StoredProcedure);
		}
		protected IDataReader LoadFromSqlReader(string sp, ListDictionary Parameters, CommandType commandType)
		{
			try
			{
				IDbCommand cmd = this.CreateIDbCommand();
				cmd.CommandText = sp;
				cmd.CommandType = commandType;				IDataParameter p;				if( Parameters != null)
				{
					foreach(DictionaryEntry param in Parameters)
					{
						p = param.Key as IDataParameter;						if(null == p)
						{
							p = this.CreateIDataParameter((string)param.Key, param.Value);
						}
						else
						{
							p.Value = param.Value;
						}						cmd.Parameters.Add(p);
					}
				}				cmd.Connection = this.CreateIDbConnection();
				cmd.Connection.ConnectionString = this.RawConnectionString;
				cmd.Connection.Open();
				return cmd.ExecuteReader(CommandBehavior.CloseConnection);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		virtual public void AddNew()
		{
			if(_dataTable == null)
			{
				this.LoadFromSql("SELECT * FROM [" +  QuerySource + "] WHERE 1=0", null, CommandType.Text);
			}			DataRow newRow = _dataTable.NewRow();
			_dataTable.Rows.Add(newRow);
			_dataRow = newRow;
		}
		virtual public void MarkAsDeleted()
		{
			if(_dataRow != null)
			{
				_dataRow.Delete();
			}
		}
		virtual public void DeleteAll()
		{
			if(_dataTable != null)
			{
				DataRow row;				DataRowCollection rows = _dataTable.Rows;
				for(int i = 0; i < rows.Count; i++)
				{
					row = rows[i];
					row.Delete();
				}
			}
		}
		virtual public void Save()
		{
			if(_dataTable == null) return;			if(!_canSave) throw new Exception("Cannot call Save() after Query.AddResultColumn()");			TransactionMgr txMgr = TransactionMgr.ThreadTransactionMgr();			try
			{
				bool needToInsert  = false;
				bool needToUpdate  = false;
				bool needToDelete  = false;				DataRow row;
				DataRowCollection rows = _dataTable.Rows;
				for(int i = 0; i < rows.Count; i++)
				{
					row = rows[i];					switch(row.RowState)
					{
						case DataRowState.Added:
							needToInsert = true;
							break;
						case DataRowState.Modified:
							needToUpdate = true;
							break;
						case DataRowState.Deleted:
							needToDelete = true;
							break;
					}
				}				if( needToInsert || needToUpdate || needToDelete)
				{
					IDbDataAdapter da = this.CreateIDbDataAdapter();					if(needToInsert) da.InsertCommand = GetInsertCommand();
					if(needToUpdate) da.UpdateCommand = GetUpdateCommand();
					if(needToDelete) da.DeleteCommand = GetDeleteCommand();					txMgr.BeginTransaction();
					int txCount = txMgr.NestingCount;
					if(txCount > 1) txMgr.AddBusinessEntity(this);					if(needToInsert) txMgr.Enlist(da.InsertCommand, this);
					if(needToUpdate) txMgr.Enlist(da.UpdateCommand, this);
					if(needToDelete) txMgr.Enlist(da.DeleteCommand, this);					DbDataAdapter dbDataAdapter = ConvertIDbDataAdapter(da);
					this.HookupRowUpdateEvents(dbDataAdapter);					dbDataAdapter.Update(_dataTable);					txMgr.CommitTransaction();
					if(txCount == 1) this.AcceptChanges();					if(needToInsert) txMgr.DeEnlist(da.InsertCommand, this);
					if(needToUpdate) txMgr.DeEnlist(da.UpdateCommand, this);
					if(needToDelete) txMgr.DeEnlist(da.DeleteCommand, this);
				}
			}
			catch(Exception ex)
			{
				if( txMgr != null) txMgr.RollbackTransaction();
				throw ex;
			}
		}
		virtual protected void HookupRowUpdateEvents(DbDataAdapter adapter)
		{
		}
		virtual public void RejectChanges()
		{
			if( _dataTable != null) _dataTable.RejectChanges();
		}
		virtual public void AcceptChanges()
		{
			if( _dataTable != null) _dataTable.AcceptChanges();
		}
		virtual public void GetChanges()
		{
			if( _dataTable != null)
			{
				this.DataTable = _dataTable.GetChanges();
			}
		}
		virtual public void GetChanges(System.Data.DataRowState rowStates)
		{
			if( _dataTable != null)
			{
				this.DataTable = _dataTable.GetChanges(rowStates);
			}
		}		
		public DynamicQuery Query
		{
			get
			{
				if(_query == null)
				{
					_query = this.CreateDynamicQuery(this);
				}				return _query;
			}
		}		internal string RawConnectionString
		{
			get
			{
				string connStr;				if (_raw != "")
					connStr = _raw;
				else
					connStr = ConfigurationManager.AppSettings[_config];
					connStr = ConfigurationSettings.AppSettings[_config];
				return connStr;
			}
		}
		public bool IsColumnNull(string columnName)
		{
			return _dataRow.IsNull(columnName);
		}
		virtual public void SetColumnNull(string columnName)
		{
			_dataRow[columnName] = DBNull.Value;
		}
		public void SetColumn(string columnName, object Value)
		{
			_dataRow[columnName] = Value;
		}
		public object GetColumn(string columnName)
		{
			return _dataRow[columnName];
		}
		protected Guid GetGuid(string columnName)
		{
			if(_dataRow.IsNull(columnName))
				return Guid.Empty;
			else
				return (Guid)_dataRow[columnName];
		}
		protected void SetGuid(string columnName, Guid data)
		{
			if( Guid.Empty.Equals(data))
				_dataRow[columnName] = DBNull.Value;
			else
				_dataRow[columnName] = data;
		}
		protected bool Getbool(string columnName)
		{
			return (bool)_dataRow[columnName];
		}
		protected void Setbool(string columnName, bool data)
		{
			_dataRow[columnName] = data;
		}
		protected string Getstring(string columnName)
		{
			if(_dataRow.IsNull(columnName))
				return String.Empty;
			else
				return (string)_dataRow[columnName];
		}
		protected void Setstring(string columnName, string data)
		{
			if(0 == data.Length)
				_dataRow[columnName] = DBNull.Value;
			else
				_dataRow[columnName] = data;
		}
		protected int Getint(string columnName)
		{
			return (int)_dataRow[columnName];
		}
		protected void Setint(string columnName, int data)
		{
			_dataRow[columnName] = data;
		}
		protected uint Getuint(string columnName)
		{
			return (uint)_dataRow[columnName];
		}
		protected void Setuint(string columnName, uint data)
		{
			_dataRow[columnName] = data;
		}
		protected long Getlong(string columnName)
		{
			return (long)_dataRow[columnName];
		}
		protected void Setlong(string columnName, long data)
		{
			_dataRow[columnName] = data;
		}
		protected ulong Getulong(string columnName)
		{
			return (ulong)_dataRow[columnName];
		}
		protected void Setulong(string columnName, ulong data)
		{
			_dataRow[columnName] = data;
		}
		protected short Getshort(string columnName)
		{
			return (short)_dataRow[columnName];
		}
		protected void Setshort(string columnName, short data)
		{
			_dataRow[columnName] = data;
		}
		protected ushort Getushort(string columnName)
		{
			return (ushort)_dataRow[columnName];
		}
		protected void Setushort(string columnName, ushort data)
		{
			_dataRow[columnName] = data;
		}
		protected DateTime GetDateTime(string columnName)
		{
			return (DateTime)_dataRow[columnName];
		}
		protected void SetDateTime(string columnName, DateTime data)
		{
			_dataRow[columnName] = data;
		}
		protected TimeSpan GetTimeSpan(string columnName)
		{
			return (TimeSpan)_dataRow[columnName];
		}
		protected void SetTimeSpan(string columnName, TimeSpan data)
		{
			_dataRow[columnName] = data;
		}
		protected decimal Getdecimal(string columnName)
		{
			return (decimal)_dataRow[columnName];
		}
		protected void Setdecimal(string columnName, decimal data)
		{
			_dataRow[columnName] = data;
		}
		protected float Getfloat(string columnName)
		{
			return (float)_dataRow[columnName];
		}
		protected void Setfloat(string columnName, float data)
		{
			_dataRow[columnName] = data;
		}
		protected double Getdouble(string columnName)
		{
			return (double)_dataRow[columnName];
		}
		protected void Setdouble(string columnName, double data)
		{
			_dataRow[columnName] = data;
		}
		protected byte Getbyte(string columnName)
		{
			return (byte)_dataRow[columnName];
		}
		protected void Setbyte(string columnName, byte data)
		{
			_dataRow[columnName] = data;
		}
		protected sbyte Getsbyte(string columnName)
		{
			return (sbyte)_dataRow[columnName];
		}
		protected void Setsbyte(string columnName, sbyte data)
		{
			_dataRow[columnName] = data;
		}
		protected object Getobject(string columnName)
		{
			return (object)_dataRow[columnName];
		}
		protected void Setobject(string columnName, object data)
		{
			_dataRow[columnName] = data;
		}		
		protected byte[] GetByteArray(string columnName)
		{
			return _dataRow[columnName] as byte[];
		}
		protected void SetByteArray(string columnName, byte[] byteArray)
		{
			_dataRow[columnName] = byteArray;
		}
		protected bool[] GetboolArray(string columnName)
		{
			return _dataRow[columnName] as bool[];
		}
		protected void SetboolArray(string columnName, bool[] data )
		{
			_dataRow[columnName] = data;
		}
		protected string[] GetstringArray(string columnName)
		{
			return _dataRow[columnName] as string[];
		}
		protected void SetstringArray(string columnName, string[] data )
		{
			_dataRow[columnName] = data;
		}
		protected int[] GetintArray(string columnName)
		{
			return _dataRow[columnName] as int[];
		}
		protected void SetintArray(string columnName, int[] data )
		{
			_dataRow[columnName] = data;
		}
		protected long[] GetlongArray(string columnName)
		{
			return _dataRow[columnName] as long[];
		}
		protected void SetlongArray(string columnName, long[] data )
		{
			_dataRow[columnName] = data;
		}
		protected short[] GetshortArray(string columnName)
		{
			return _dataRow[columnName] as short[];
		}
		protected void SetshortArray(string columnName, short[] data )
		{
			_dataRow[columnName] = data;
		}
		protected DateTime[] GetDateTimeArray(string columnName)
		{
			return _dataRow[columnName] as DateTime[];
		}
		protected void SetDateTimeArray(string columnName, DateTime[] data )
		{
			_dataRow[columnName] = data;
		}
		protected decimal[] GetdecimalArray(string columnName)
		{
			return _dataRow[columnName] as decimal[];
		}
		protected void SetdecimalArray(string columnName, decimal[] data )
		{
			_dataRow[columnName] = data;
		}
		protected float[] GetfloatArray(string columnName)
		{
			return _dataRow[columnName] as float[];
		}
		protected void SetfloatArray(string columnName, float[] data )
		{
			_dataRow[columnName] = data;
		}
		protected double[] GetdoubleArray(string columnName)
		{
			return _dataRow[columnName] as double[];
		}
		protected void SetdoubleArray(string columnName, double[] data )
		{
			_dataRow[columnName] = data;
		}
		protected string GetGuidAsString(string columnName)
		{
			return _dataRow[columnName].ToString();
		}
		protected Guid SetGuidAsString(string columnName, string data)
		{
			return new Guid(data);
		}
		protected string GetboolAsString(string columnName)
		{
			return _dataRow[columnName].ToString();
		}
		protected bool SetboolAsString(string columnName, string data)
		{
			return Convert.ToBoolean(data);
		}
		protected string GetstringAsString(string columnName)
		{
			return (string)_dataRow[columnName];
		}
		protected string SetstringAsString(string columnName, string data)
		{
			return data;
		}
		protected string GetintAsString(string columnName)
		{
			return _dataRow[columnName].ToString();
		}
		protected int SetintAsString(string columnName, string data)
		{
			return Convert.ToInt32(data);
		}
		protected string GetuintAsString(string columnName)
		{
			return _dataRow[columnName].ToString();
		}
		protected uint SetuintAsString(string columnName, string data)
		{
			return Convert.ToUInt32(data);
		}
		protected string GetlongAsString(string columnName)
		{
			return _dataRow[columnName].ToString();
		}
		protected long SetlongAsString(string columnName, string data)
		{
			return Convert.ToInt64(data);
		}
		protected string GetshortAsString(string columnName)
		{
			return _dataRow[columnName].ToString();
		}
		protected short SetshortAsString(string columnName, string data)
		{
			return Convert.ToInt16(data);
		}
		protected string GetushortAsString(string columnName)
		{
			return _dataRow[columnName].ToString();
		}
		protected ushort SetushortAsString(string columnName, string data)
		{
			return Convert.ToUInt16(data);
		}
		protected string GetDateTimeAsString(string columnName)
		{
			return ((DateTime)_dataRow[columnName]).ToString(this.StringFormat);
		}
		protected DateTime SetDateTimeAsString(string columnName, string data)
		{
			return Convert.ToDateTime(data);
		}
		protected string GetTimeSpanAsString(string columnName)
		{
			return ((TimeSpan)_dataRow[columnName]).ToString();
		}
		protected TimeSpan SetTimeSpanAsString(string columnName, string data)
		{
			return TimeSpan.Parse(data);
		}
		protected string GetdecimalAsString(string columnName)
		{
			return _dataRow[columnName].ToString();
		}
		protected decimal SetdecimalAsString(string columnName, string data)
		{
			return Convert.ToDecimal(data);
		}
		protected string GetfloatAsString(string columnName)
		{
			return _dataRow[columnName].ToString();
		}
		protected Single SetfloatAsString(string columnName, string data)
		{
			return Convert.ToSingle(data);
		}
		protected string GetdoubleAsString(string columnName)
		{
			return _dataRow[columnName].ToString();
		}
		protected double SetdoubleAsString(string columnName, string data)
		{
			return Convert.ToDouble(data);
		}
		protected string GetbyteAsString(string columnName)
		{
			return _dataRow[columnName].ToString();
		}
		protected byte SetbyteAsString(string columnName, string data)
		{
			return Convert.ToByte(data);
		}
		protected string GetsbyteAsString(string columnName)
		{
			return _dataRow[columnName].ToString();
		}
		protected sbyte SetsbyteAsString(string columnName, string data)
		{
			return Convert.ToSByte(data);
		}
		#endregion
		protected DataRow _dataRow = null;
		private DataTable _dataTable = null;
        private IEnumerator _enumerator = null; private static string _defaultConfig = "dbConnectionRAFMain";
		internal string _config = BusinessEntity._defaultConfig;
		internal IDbConnection _notRecommendedConnection = null;
		internal string _raw = "";
		internal bool   _canSave = true;		private DynamicQuery _query;		private string _querySource = "";
		private string _schemaGlobal = "";
		private string _tableViewSchema = "";
		private string _storedProcSchema = "";
		private string _mappingName = "";
		private bool _EOF = true;
	}
}
