using System;
using SalaryCalc.Controllers;
using SalaryCalc.Views.ViewFields;

namespace SalaryCalc.Views
{
    internal class ExitView
    {
        public ViewResultController View()
        {
            Console.Clear();
            Console.CursorVisible = false;

            ViewTools.Txt(top: 2, left: 3, text: "Всего хорошего, досвидания");
            ViewTools.Txt(top: 3, left: 3, text: "--------------------------------------------");

            return null;
        }
    }
}
