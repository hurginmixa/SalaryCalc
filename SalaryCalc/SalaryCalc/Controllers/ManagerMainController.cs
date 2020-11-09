using System;
using System.Linq;
using SalaryCalc.Views;
using SalaryCalc.Views.ViewFields;

namespace SalaryCalc.Controllers
{
    internal class ManagerMainController : ControllerBase
    {
        public override ViewRequestBase Run(ViewResult viewResult)
        {
            if (viewResult.Fields.Count() == 0)
            {
                return new ViewRequest<ManagerMainView>();
            }

            if (viewResult.InputFieldResult != eInputFieldResult.Ok)
            {
                return new ViewRequest<ExitView>();
            }

            var choose = viewResult.Fields["Choose"].Value;

            if (choose == "0")
            {
                return new ViewRequest<ExitView>();
            }

            return new ViewRequest<ManagerMainView>();
        }
    }
}