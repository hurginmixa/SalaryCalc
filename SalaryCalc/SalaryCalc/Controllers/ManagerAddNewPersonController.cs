using SalaryCalc.Views;
using SalaryCalc.Views.ViewClasses;

namespace SalaryCalc.Controllers
{
    class ManagerAddNewPersonController : ControllerBase
    {
        public override ViewRequest Run(ViewResult viewResult)
        {
            if (viewResult.ViewStatus == eViewStatus.Cancel)
            {
                return new ViewRequest<ManagerMainView>();
            }

            return new ViewRequest<ManagerAddNewPersonView>(new ViewInput("Bad User", viewResult.Values));
        }
    }
}
