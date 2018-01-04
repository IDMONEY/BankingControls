using System.Collections;
using System.Data;
namespace Raf.Dal
{


	public class AggregateParameter
	{
		public enum Func
		{
			Avg = 1,
			Count,
			Max,
			Min,
			StdDev,
			Var,
			Sum
		};
		public AggregateParameter(string column, IDataParameter param)
		{
			this._column = column;
			this._alias = column;
			this._distinct = false;
			this._param = param;
			this._function = AggregateParameter.Func.Sum;
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
		public Func Function
		{
			get
			{
				return _function;
			}
			set
			{
				_function = value;
				_isDirty = true;
			}
		}
		public string Alias
		{
			get
			{
				return _alias;
			}
			set
			{
				_alias = value;
				_isDirty = true;
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
				_isDirty = true;
			}
		}
		private object _value = null;
		private IDataParameter _param;
		private string _column;
		private Func _function = AggregateParameter.Func.Sum;
		private string _alias = string.Empty;
		private bool _isDirty = false;
		private bool _distinct = false;
	}
}
