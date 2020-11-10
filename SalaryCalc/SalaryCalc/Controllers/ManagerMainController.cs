using System;
using System.Linq;
using SalaryCalc.Views;
using SalaryCalc.Views.ViewClasses;
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

            if (viewResult.ViewStatus != eViewStatus.Ok)
            {
                return new ViewRequest<ManagerMainView>();
            }

            string choose = viewResult.Fields["Choose"].Value;
            switch (choose)
            {
                case "5":
                    return new ViewRequest<LoginView>();

                case "1":
                    return new ViewRequest<ManagerAddNewPersonView>();
                
                default:
                    return new ViewRequest<ManagerMainView>();
            }
        }
    }
}