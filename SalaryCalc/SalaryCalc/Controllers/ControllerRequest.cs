using SalaryCalc.Views;
using SalaryCalc.Views.ViewFields;

namespace SalaryCalc.Controllers
{
    internal class ControllerRequest
    {
        public ControllerRequest(eInputFieldResult inputFieldResult, FieldList fields, ControllerBase controller)
        {
            ViewResult = new ViewResult(inputFieldResult, fields);

            Controller = controller;
        }

        public ViewResult ViewResult { get; }

        public ControllerBase Controller { get; }
    }
}