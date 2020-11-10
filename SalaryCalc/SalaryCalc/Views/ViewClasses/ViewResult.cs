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
}