using System.Collections.Generic;
using System.Linq;

namespace MyHomeMVC.Views
{
    public class ResultValueList
    {
        private readonly List<ResultValue> _list;

        public ResultValueList()
        {
            _list = new List<ResultValue>();
        }

        public ResultValueList(IEnumerable<ResultValue> fieldList) : this()
        {
            _list = fieldList.ToList();
        }

        public int Count() => _list.Count;

        public string this[string name] => _list.First(v => v.Name == name).Value;
    }
}