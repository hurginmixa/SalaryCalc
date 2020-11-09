using SalaryCalc.Views.ViewFields;

namespace SalaryCalc.Views.ViewClasses
{
    internal class ViewResult
    {
        public ViewResult(eViewStatus viewStatus, FieldList fields)
        {
            ViewStatus = viewStatus;
            Fields = fields;
        }

        public eViewStatus ViewStatus { get; }

        public FieldList Fields { get; }
    }
}