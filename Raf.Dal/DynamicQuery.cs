using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Collections;
namespace Raf.Dal
{
    abstract public class DynamicQuery
    {
        abstract protected IDbCommand _Load(string conjuction);
        public DynamicQuery(BusinessEntity entity)
        {
            this._entity = entity;
        }
        private IDbCommand _Load()
        {
            return _Load("AND");
        }
        public bool Load()
        {
            return Load("AND");
        }
        public bool Load(string conjuction)
        {
            bool loaded = false;
            DataTable dt = null;
            try
            {
                if ((_aggregateParameters == null || _aggregateParameters.Count <= 0)
                    && _resultColumns.Length <= 0 && _countAll == false)
                {
                    this._entity._canSave = true;
                }
                this._entity.OnQueryLoad(conjuction);
                IDbCommand cmd = _Load(conjuction);
                _lastQuery = cmd.CommandText;
                IDbDataAdapter da = this._entity.CreateIDbDataAdapter();
                da.SelectCommand = cmd;
                TransactionMgr txMgr = TransactionMgr.ThreadTransactionMgr();
                dt = new DataTable(_entity.MappingName);
                txMgr.Enlist(cmd, _entity);
                DbDataAdapter dbDataAdapter = this._entity.ConvertIDbDataAdapter(da);
                dbDataAdapter.Fill(dt);
                txMgr.DeEnlist(cmd, _entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._entity.DataTable = dt;
                loaded = (dt.Rows.Count > 0);
            }
            return loaded;
        }
        public string GenerateSQL()
        {
            return GenerateSQL("AND");
        }
        public string LastQuery
        {
            get
            {
                return _lastQuery;
            }
        }
        public string GenerateSQL(string conjuction)
        {
            string sql = "";
            try
            {
                IDbCommand cmd = _Load(conjuction);
                sql = cmd.CommandText;
            }
            catch (Exception) { }
            return sql;
        }
        public IDataReader ReturnReader()
        {
            return ReturnReader("AND");
        }
        public IDataReader ReturnReader(string conjuction)
        {
            try
            {
                IDbCommand cmd = _Load(conjuction);
                cmd.Connection = this._entity.CreateIDbConnection();
                cmd.Connection.ConnectionString = _entity.RawConnectionString;
                cmd.Connection.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Top
        {
            get
            {
                return _top;
            }
            set
            {
                _top = value;
            }
        }
        public bool Distinct
        {
            get
            {
                return _distinct;
            }
            set
            {
                _distinct = value;
            }
        }
        public bool CountAll
        {
            get
            {
                return _countAll;
            }
            set
            {
                _countAll = value;
                if (value)
                {
                    this._entity._canSave = false;
                }
            }
        }
        public string CountAllAlias
        {
            get
            {
                return _countAllAlias;
            }
            set
            {
                _countAllAlias = value;
            }
        }
        public bool WithRollup
        {
            get
            {
                return _withRollup;
            }
            set
            {
                _withRollup = value;
            }
        }
        public void AddWhereParameter(WhereParameter wItem)
        {
            if (_whereParameters == null)
            {
                _whereParameters = new ArrayList();
            }
            _whereParameters.Add(wItem);
        }
        public int ParameterCount
        {
            get
            {
                int count = 0;
                if (_whereParameters != null)
                {
                    count = _whereParameters.Count;
                }
                return count;
            }
        }
        public void AddAggregateParameter(AggregateParameter wItem)
        {
            if (_aggregateParameters == null)
            {
                _aggregateParameters = new ArrayList();
            }
            _aggregateParameters.Add(wItem);
            this._entity._canSave = false;
        }
        public int AggregateCount
        {
            get
            {
                int count = 0;
                if (_aggregateParameters != null)
                {
                    count = _aggregateParameters.Count;
                }
                return count;
            }
        }
        public virtual void AddOrderBy(string column, WhereParameter.Dir direction)
        {
            if (_orderBy.Length > 0)
            {
                _orderBy += ", ";
            }
            _orderBy += column;
            if (direction == WhereParameter.Dir.ASC)
                _orderBy += " ASC";
            else
                _orderBy += " DESC";
        }
        public virtual void AddOrderBy(DynamicQuery countAll, WhereParameter.Dir direction)
        {
        }
        public virtual void AddOrderBy(AggregateParameter aggregate, WhereParameter.Dir direction)
        {
        }
        public virtual void AddGroupBy(string column)
        {
            if (_groupBy.Length > 0)
            {
                _groupBy += ", ";
            }
            _groupBy += column;
        }
        public virtual void AddGroupBy(AggregateParameter aggregate)
        {
        }
        public void FlushWhereParameters()
        {
            if (_whereParameters != null)
            {
                _whereParameters.Clear();
            }
            _orderBy = string.Empty;
        }
        public void FlushAggregateParameters()
        {
            if (_aggregateParameters != null)
            {
                _aggregateParameters.Clear();
            }
            _countAll = false;
            _countAllAlias = string.Empty;
            _groupBy = string.Empty;
        }
        public virtual void AddResultColumn(string columnName)
        {
            if (_resultColumns.Length > 0)
            {
                _resultColumns += ", ";
            }
            _resultColumns += columnName;
            this._entity._canSave = false;
        }
        public void ResultColumnsClear()
        {
            _resultColumns = string.Empty;
        }
        public void AddConjunction(WhereParameter.Conj conjuction)
        {
            if (_whereParameters == null)
            {
                _whereParameters = new ArrayList();
            }
            if (conjuction != WhereParameter.Conj.UseDefault)
            {
                if (conjuction == WhereParameter.Conj.And)
                    _whereParameters.Add(" AND ");
                else
                    _whereParameters.Add(" OR ");
            }
        }
        public void OpenParenthesis()
        {
            if (_whereParameters == null)
            {
                _whereParameters = new ArrayList();
            }
            _whereParameters.Add("(");
        }
        public void CloseParenthesis()
        {
            if (_whereParameters == null)
            {
                _whereParameters = new ArrayList();
            }
            _whereParameters.Add(")");
        }
        protected bool _distinct = false;
        protected int _top = -1;
        protected bool _countAll = false;
        protected string _countAllAlias = string.Empty;
        protected bool _withRollup = false;
        protected ArrayList _whereParameters = null;
        protected ArrayList _aggregateParameters = null;
        protected string _resultColumns = string.Empty;
        protected string _orderBy = string.Empty;
        protected string _groupBy = string.Empty;
        protected BusinessEntity _entity;
        protected int inc = 0;
        private string _lastQuery = "";
    }
}