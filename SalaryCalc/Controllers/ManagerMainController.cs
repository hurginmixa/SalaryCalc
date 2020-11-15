﻿using System;
using System.Linq;
using MyHomeMVC.Controllers;
using MyHomeMVC.Views;
using SalaryCalc.Views;

namespace SalaryCalc.Controllers
{
    internal class ManagerMainController : ControllerBase
    {
        public enum eAction
        {
            None,
            ExitProgram,
            ChangeUser,
            AddNewPerson,
            ShowWorkerList
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

            var choose = Enum.Parse<eAction>(viewResult.Values["Choose"], ignoreCase: true);
            switch (choose)
            {
                case eAction.ExitProgram:
                    return new ViewRequest<ExitView>();

                case eAction.ChangeUser:
                    return new ViewRequest<LoginView>();

                case eAction.AddNewPerson:
                    return new ViewRequest<ManagerAddNewPersonView>();
                
                default:
                    return new ViewRequest<ManagerMainView>();
            }
        }
    }
}