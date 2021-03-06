﻿using MyHomeMVC.Controllers;
using MyHomeMVC.Views;
using SalaryCalc.Models;
using SalaryCalc.Views;

namespace SalaryCalc.Controllers
{
    internal class AskToExitController : ControllerBase
    {
        public override ViewRequest Run(ViewResult viewResult)
        {
            if (viewResult.ViewStatus == eViewStatus.Ok)
            {
                return new ViewRequest<ExitView>();
            }

            return ApplicationData.CurrentData.GetMainViewForCurrentPearson();
        }
    }
}