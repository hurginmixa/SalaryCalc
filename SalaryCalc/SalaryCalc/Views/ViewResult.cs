using SalaryCalc.Views.ViewFields;

namespace SalaryCalc.Views
{
    internal class ViewResult
    {
        public ViewResult(eInputFieldResult inputFieldResult, FieldList fields)
        {
            InputFieldResult = inputFieldResult;
            Fields = fields;
        }

        public eInputFieldResult InputFieldResult { get; }

        public FieldList Fields { get; }
    }
}