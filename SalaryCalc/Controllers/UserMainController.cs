using System;
using MyHomeMVC.Controllers;
using MyHomeMVC.Views;
using SalaryCalc.Views;

namespace SalaryCalc.Controllers
{
    internal class UserMainController : ControllerBase
    {
        public enum eAction
        {
            None,
            Exit,
            ChangeUser,
            AddWorkTime
        }

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

            eAction choose = Enum.Parse<eAction>(viewResult.Values["Choose"]);
            switch (choose)
            {
                case eAction.Exit:
                    return new ViewRequest<ExitView>();

                case eAction.ChangeUser:
                    return new ViewRequest<LoginView>();
               
                default:
                    return new ViewRequest<UserMainView>();
            }
        }
    }
}