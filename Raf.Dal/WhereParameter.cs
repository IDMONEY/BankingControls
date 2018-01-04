using System.Collections;
using System.Data;
namespace Raf.Dal
{
    public class WhereParameter
    {
        public enum Operand
        {
            Equal = 1,
            NotEqual,
            GreaterThan,
            GreaterThanOrEqual,
            LessThan,
            LessThanOrEqual,
            Like,
            IsNull,
            IsNotNull,
            Between,
            In,
            NotIn,
            NotLike
        };
        public enum Dir
        {
            ASC = 1,
            DESC
        };
        public enum Conj
        {
            And = 1,
            Or,
            UseDefault
        };
        public WhereParameter(string column, IDataParameter param)
        {
            this._column = column;
            this._param = param;
            this._operator = Operand.Equal;
        }
        public bool IsDirty
        {
            get
            {
                return _isDirty;
            }
        }
        public string Column
        {
            get
            {
                return _column;
            }
        }
        public IDataParameter Param
        {
            get
            {
                return _param;
            }
        }
        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                _isDirty = true;
            }
        }
        public Operand Operator
        {
            get
            {
                return _operator;
            }
            set
            {
                _operator = value;
                _isDirty = true;
            }
        }
        public Conj Conjuction
        {
            get
            {
                return _conjuction;
            }
            set
            {
                _conjuction = value;
                _isDirty = true;
            }
        }
        public object BetweenBeginValue
        {
            get
            {
                return _betweenBegin;
            }
            set
            {
                _betweenBegin = value;
                _isDirty = true;
            }
        }
        public object BetweenEndValue
        {
            get
            {
                return _betweenEnd;
            }
            set
            {
                _betweenEnd = value;
                _isDirty = true;
            }
        }
        private Operand _operator;
        private Conj _conjuction = Conj.UseDefault;
        private object _value = null;
        private string _column;
        private IDataParameter _param;
        private bool _isDirty = false;
        private object _betweenBegin = null;
        private object _betweenEnd = null;
    }
}