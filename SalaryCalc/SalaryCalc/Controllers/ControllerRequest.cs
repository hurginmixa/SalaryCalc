using SalaryCalc.Views.ViewClasses;
using SalaryCalc.Views.ViewFields;

namespace SalaryCalc.Controllers
{
    internal abstract class ControllerRequestBase
    {
        private readonly ViewResult _viewResult;

        protected ControllerRequestBase(eViewStatus viewStatus, FieldList fields)
        {
            _viewResult = new ViewResult(viewStatus, fields);
        }

        public ViewRequestBase RunController() => Controller.Run(_viewResult);

        protected abstract ControllerBase Controller { get; }
    }

    internal class ControllerRequest<TControllerBase> : ControllerRequestBase where TControllerBase : ControllerBase, new()
    {
        public ControllerRequest(eViewStatus viewStatus, FieldList fields) : base(viewStatus, fields)
        {
        }

        protected override ControllerBase Controller => new TControllerBase();
    }
}