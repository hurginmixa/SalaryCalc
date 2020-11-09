using System;
using SalaryCalc.Controllers;
using SalaryCalc.Views.ViewClasses;
using SalaryCalc.Views.ViewFields;

namespace SalaryCalc.Views
{
    internal class ExitView : ViewBase
    {
        public override ControllerRequest View(object model)
        {
            Console.Clear();
            Console.CursorVisible = false;

            ViewTools.Txt(top: 2, left: 3, text: "Всего хорошего, досвидания");
            ViewTools.Txt(top: 3, left: 3, text: "--------------------------------------------");

            return null;
        }
    }
}
