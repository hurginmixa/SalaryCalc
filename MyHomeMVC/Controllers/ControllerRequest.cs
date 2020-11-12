using MyHomeMVC.Views;

namespace MyHomeMVC.Controllers
{
    public abstract class ControllerRequest
    {
        private readonly ViewResult _viewResult;

        protected ControllerRequest(eViewStatus viewStatus, ResultValueList valueList)
        {
            _viewResult = new ViewResult(viewStatus, valueList);
        }

        public ViewRequest RunController() => Controller.Run(_viewResult);

        protected abstract ControllerBase Controller { get; }
    }

    public class ControllerRequest<TControllerBase> : ControllerRequest where TControllerBase : ControllerBase, new()
    {
        public ControllerRequest(eViewStatus viewStatus, ResultValueList valueList) : base(viewStatus, valueList)
        {
        }

        protected override ControllerBase Controller => new TControllerBase();
    }
}