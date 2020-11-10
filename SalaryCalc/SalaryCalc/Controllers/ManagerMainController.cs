﻿using System;
using System.Linq;
using SalaryCalc.Views;
using SalaryCalc.Views.ViewClasses;
using SalaryCalc.Views.ViewFields;

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
                return new ViewRequest<ManagerMainView>();
            }

            string choose = viewResult.Values["Choose"];
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