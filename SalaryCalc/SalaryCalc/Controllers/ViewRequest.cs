using SalaryCalc.Views;
using SalaryCalc.Views.ViewClasses;

namespace SalaryCalc.Controllers
{
    internal abstract class ViewRequestBase
    {
        protected abstract ViewBase View { get; }

        protected abstract object Model { get; }

        public ControllerRequest RunView()
        {
            return View.View(model: Model);
        }
    }

    internal class ViewRequest<T> : ViewRequestBase where T : ViewBase, new()
    {
        public ViewRequest(object model)
        {
            Model = model;
        }

        public ViewRequest() : this(null)
        {
        }

        protected override ViewBase View => new T();

        protected override object Model { get; }
    }
}