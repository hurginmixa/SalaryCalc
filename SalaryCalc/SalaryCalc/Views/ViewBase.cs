using SalaryCalc.Controllers;

namespace SalaryCalc.Views
{
    internal abstract class ViewBase
    {
        public abstract ControllerRequest View(object model);
    }
}