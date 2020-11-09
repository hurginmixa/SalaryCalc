using System;
using SalaryCalc.Views;
using SalaryCalc.Views.ViewFields;

namespace SalaryCalc.Controllers
{
    internal class LoginController : ControllerBase
    {
        public override ViewRequestBase Run(ViewResult viewResult)
        {
            if (viewResult.Fields.Count() == 0)
            {
                return new ViewRequest<LoginView>();
            }

            if (viewResult.InputFieldResult == eInputFieldResult.Cancel)
            {
                return new ViewRequest<ExitView>();
            }

            return new ViewRequest<ManagerMainView>();
        }
    }
}
