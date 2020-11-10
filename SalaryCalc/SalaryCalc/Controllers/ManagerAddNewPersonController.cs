using SalaryCalc.Views;
using SalaryCalc.Views.ViewClasses;

namespace SalaryCalc.Controllers
{
    class ManagerAddNewPersonController : ControllerBase
    {
        public override ViewRequestBase Run(ViewResult viewResult)
        {
            if (viewResult.ViewStatus == eViewStatus.Cancel)
            {
                return new ViewRequest<ManagerMainView>();
            }

            throw new System.NotImplementedException();
        }
    }
}
