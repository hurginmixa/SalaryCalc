using System;
using SalaryCalc.Controllers;
using SalaryCalc.Views.ViewFields;

namespace SalaryCalc.Views
{
    internal class ManagerMainView
    {
        public ViewResultController View()
        {
            Console.Clear();
            Console.CursorVisible = false;

            ViewTools.Txt(top: 2, left: 3, text: "Главный экран Менеджера");
            ViewTools.Txt(top: 3, left: 3, text: "--------------------------------------------");
            ViewTools.Txt(top: 4, left: 3, text: "0 - Выход");

            ViewTools.Txt(top: 5, left: 3, text: "Ваш выбор : ");

            FieldList fields = new FieldList().Add(new ChooseField(top: 5, left: 13, name: "Choose"));

            var inputFieldResult = fields.Input();

            return new ViewResultController(inputFieldResult, fields, new ManagerMainController());
        }
    }
}