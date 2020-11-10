using SalaryCalc.Views.ViewClasses;
using SalaryCalc.Views.ViewFields;

namespace SalaryCalc.Controllers
{
    internal abstract class ControllerRequest
    {
        private readonly ViewResult _viewResult;

        protected ControllerRequest(eViewStatus viewStatus, ResultValueList fields)
        {
            _viewResult = new ViewResult(viewStatus, fields);
        }

        public ViewRequest RunController() => Controller.Run(_viewResult);

        protected abstract ControllerBase Controller { get; }
    }

    internal class ControllerRequest<TControllerBase> : ControllerRequest where TControllerBase : ControllerBase, new()
    {
        public ControllerRequest(eViewStatus viewStatus, ResultValueList fields) : base(viewStatus, fields)
        {
        }

        protected override ControllerBase Controller => new TControllerBase();
    }
}