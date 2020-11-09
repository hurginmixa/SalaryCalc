using SalaryCalc.Views;

namespace SalaryCalc.Controllers
{
    internal class ViewRequest
    {
        public ViewRequest(ViewBase view, object model)
        {
            View = view;

            Model = model;
        }

        public ViewRequest(ViewBase view) : this(view, null)
        {
        }

        public ViewBase View { get; }
        
        public object Model { get; }
    }
}