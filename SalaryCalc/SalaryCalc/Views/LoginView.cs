using System;
using System.Collections.Generic;
using SalaryCalc.Controllers;
using SalaryCalc.Views.ViewFields;

namespace SalaryCalc.Views
{
    internal class LoginView
    {
        public ViewResultController View()
        {
            Console.Clear();
            Console.CursorVisible = false;

            ViewTools.Txt(top: 2, left: 3, text: "Добро пожаловать, представтесь пожалуйста");
            ViewTools.Txt(top: 3, left: 3, text: "--------------------------------------------");
            ViewTools.Txt(top: 4, left: 3, text: "Имя     :");
            ViewTools.Txt(top: 5, left: 3, text: "Фамилия :");

            FieldList fields = new FieldList()
                .Add(new EditField(top: 4, left: 13, length: 15, name: "FirstName", text: ""))
                .Add(new EditField(top: 5, left: 13, length: 15, name: "SecondName", text: ""))
                .Add(new WaitOkField(top: 6, left: 3, name: "Ok", text: "[ Ok ]"));

            eInputFieldResult inputFieldResult = fields.Input();

            return new ViewResultController(inputFieldResult, fields, new LoginController());
        }
    }
}
