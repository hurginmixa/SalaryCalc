﻿using System;
using MyHomeMVC.Controllers;
using MyHomeMVC.Views;
using SalaryCalc.Controllers;
using SalaryCalc.ViewHelpers;

namespace SalaryCalc.Views
{
    internal class ExitView : ViewBase
    {
        public override ControllerRequest View(object model)
        {
            Console.Clear();
            Console.CursorVisible = false;

            ViewTools.Txt(top: 2, left: 3, text: "Всего хорошего, до свидания");
            ViewTools.Txt(top: 3, left: 3, text: "--------------------------------------------");

            ViewTools.Txt(top: 13, left: 3, text: "");

            return null;
        }
    }
}
