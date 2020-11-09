using System;
using SalaryCalc.Views;
using SalaryCalc.Views.ViewFields;

namespace SalaryCalc.Controllers
{
    internal class LoginController : Controller
    {
        public override ViewResultController Run(ViewResult viewResult)
        {
            if (viewResult.InputFieldResult == eInputFieldResult.Cancel)
            {
                return new ExitView().View();
            }

            return new ManagerMainView().View();
        }
    }
}
