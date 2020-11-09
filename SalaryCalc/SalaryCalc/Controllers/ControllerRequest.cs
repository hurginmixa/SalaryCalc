using SalaryCalc.Views;
using SalaryCalc.Views.ViewClasses;
using SalaryCalc.Views.ViewFields;

namespace SalaryCalc.Controllers
{
    internal class ControllerRequest
    {
        private readonly ViewResult _viewResult;
        private readonly ControllerBase _controller;

        public ControllerRequest(ControllerBase controller, eViewStatus viewStatus, FieldList fields)
        {
            _viewResult = new ViewResult(viewStatus, fields);

            _controller = controller;
        }

        public ViewRequestBase RunController() => _controller.Run(_viewResult);
    }
}