using SalaryCalc.Views;
using SalaryCalc.Views.ViewFields;

namespace SalaryCalc.Controllers
{
    internal class ControllerRequest
    {
        public ControllerRequest(eInputFieldResult inputFieldResult, FieldList fields, Controller controller)
        {
            ViewResult = new ViewResult(inputFieldResult, fields);

            Controller = controller;
        }

        public ViewResult ViewResult { get; }

        public Controller Controller { get; }
    }
}