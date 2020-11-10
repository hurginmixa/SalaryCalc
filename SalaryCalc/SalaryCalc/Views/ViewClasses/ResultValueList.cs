using System.Collections.Generic;
using System.Linq;
using SalaryCalc.Views.ViewFields;

namespace SalaryCalc.Views.ViewClasses
{
    internal class ResultValueList
    {
        private readonly List<ResultValue> _list;

        public ResultValueList()
        {
            _list = new List<ResultValue>();
        }

        public ResultValueList(IEnumerable<Field> fieldList) : this()
        {
            _list = fieldList.Select(f => new ResultValue(f.Name, f.Value)).ToList();
        }

        public int Count() => _list.Count;

        public ResultValue this[string name] => _list.First(v => v.Name == name);
    }
}