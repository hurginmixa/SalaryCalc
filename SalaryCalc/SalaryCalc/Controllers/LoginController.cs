using System;
using SalaryCalc.Views;
using SalaryCalc.Views.ViewFields;

namespace SalaryCalc.Controllers
{
    internal class LoginController : Controller
    {
        public override ViewRequest Run(ViewResult viewResult)
        {
            if (viewResult.Fields.Count() == 0)
            {
                return new ViewRequest(new LoginView());
            }

            if (viewResult.InputFieldResult == eInputFieldResult.Cancel)
            {
                return new ViewRequest(new ExitView());
            }

            return new ViewRequest(new ManagerMainView());
        }
    }
}
