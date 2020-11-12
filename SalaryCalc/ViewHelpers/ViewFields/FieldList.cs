using System.Collections.Generic;
using System.Linq;
using MyHomeMVC.Views;

namespace SalaryCalc.ViewHelpers.ViewFields
{
    internal class FieldList
    {
        readonly List<Field> _fields = new List<Field>();

        public FieldList Add(Field field)
        {
            _fields.Add(field);

            return this;
        }

        public eViewStatus Input()
        {
            foreach (var field in _fields)
            {
                field.Draw();
            }

            int iCurrentFiend = 0;

            var currentFiend = _fields[iCurrentFiend];

            eInputFieldResult inputFieldResult = currentFiend.Input();

            while (inputFieldResult != eInputFieldResult.Ok && inputFieldResult != eInputFieldResult.Cancel)
            {
                if (inputFieldResult == eInputFieldResult.PrevField)
                {
                    iCurrentFiend = iCurrentFiend > 0 ? iCurrentFiend - 1 : _fields.Count - 1;
                }
                else
                {
                    iCurrentFiend = iCurrentFiend >= _fields.Count - 1 ? 0 : iCurrentFiend + 1;
                }

                currentFiend = _fields[iCurrentFiend];

                inputFieldResult = currentFiend.Input();
            }

            return inputFieldResult == eInputFieldResult.Ok ? eViewStatus.Ok : eViewStatus.Cancel;
        }

        public ResultValueList ToResultValueList() => new ResultValueList(_fields.Select(f => new ResultValue(f.Name, f.Value)));
    }
}
