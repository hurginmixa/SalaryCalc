using SalaryCalc.Controllers;

namespace SalaryCalc.Views.ViewClasses
{
    internal abstract class ViewBase
    {
        public abstract ControllerRequestBase View(object model);
    }
}