using System.Collections.Generic;
using System.Linq;
using SalaryCalc.Views.ViewFields;

namespace SalaryCalc.Views.ViewClasses
{
    internal class ViewResult
    {
        public ViewResult(eViewStatus viewStatus, ResultValueList fields)
        {
            ViewStatus = viewStatus;
            Fields = fields;
        }

        public eViewStatus ViewStatus { get; }

        public ResultValueList Fields { get; }
    }

    internal class ResultValue
    {
        public ResultValue(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }

        public string Value { get; }
    }

    internal class ResultValueList
    {
        private readonly List<ResultValue> _list;

        public ResultValueList()
        {
            _list = new List<ResultValue>();
        }

        public ResultValueList(FieldList fieldList) : this()
        {
            _list = fieldList.List.Select(f => new ResultValue(f.Name, f.Value)).ToList();
        }

        public int Count() => _list.Count;

        public ResultValue this[string firstname]
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}