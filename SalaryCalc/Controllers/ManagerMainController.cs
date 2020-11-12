using System;
using System.Linq;
using MyHomeMVC.Controllers;
using MyHomeMVC.Views;
using SalaryCalc.Views;

namespace SalaryCalc.Controllers
{
    internal class ManagerMainController : ControllerBase
    {
        public override ViewRequest Run(ViewResult viewResult)
        {
            if (viewResult.Values.Count() == 0)
            {
                return new ViewRequest<ManagerMainView>();
            }

            if (viewResult.ViewStatus != eViewStatus.Ok)
            {
                return new ViewRequest<AskToExitView>();
            }

            string choose = viewResult.Values["Choose"];
            switch (choose)
            {
                case "5":
                    return new ViewRequest<ExitView>();

                case "6":
                    return new ViewRequest<LoginView>();

                case "1":
                    return new ViewRequest<ManagerAddNewPersonView>();
                
                default:
                    return new ViewRequest<ManagerMainView>();
            }
        }
    }
}