using SalaryCalc.Views;

namespace SalaryCalc.Controllers
{
    internal abstract class ViewRequestBase
    {
        public abstract ViewBase View { get; }
        
        public abstract object Model { get; }
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

        public override ViewBase View => new T();
        
        public override object Model { get; }
    }
}