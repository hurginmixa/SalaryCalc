using MyHomeMVC.Views;

namespace MyHomeMVC.Controllers
{
    public abstract class ViewRequest
    {
        protected abstract ViewBase View { get; }

        protected abstract object Model { get; }

        public ControllerRequest RunView()
        {
            return View.View(model: Model);
        }
    }

    public class ViewRequest<T> : ViewRequest where T : ViewBase, new()
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