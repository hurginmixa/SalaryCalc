using System;
using System.Collections.Generic;
using SalaryCalc.Controllers;
using SalaryCalc.Views.ViewClasses;
using SalaryCalc.Views.ViewFields;

namespace SalaryCalc.Views
{
    internal class LoginView : ViewBase
    {
        public override ControllerRequest View(object model)
        {
            Console.Clear();
            Console.CursorVisible = false;

            ViewTools.Txt(top: 2, left: 3, text: "Добро пожаловать, представтесь пожалуйста");
            ViewTools.Txt(top: 3, left: 3, text: "--------------------------------------------");
            ViewTools.Txt(top: 4, left: 3, text: "Имя     :");
            ViewTools.Txt(top: 5, left: 3, text: "Фамилия :");

            FieldList fields = new FieldList()
                .Add(new EditField(top: 4, left: 13, length: 15, name: "FirstName", text: ""))
                .Add(new EditField(top: 5, left: 13, length: 15, name: "LastName", text: ""))
                .Add(new WaitOkField(top: 6, left: 3, name: "Ok", text: "[ Ok ]"));

            if (model is string message && !string.IsNullOrWhiteSpace(message))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                ViewTools.Txt(top: 8, left: 3, length: 20, text: message);
                Console.ResetColor();
            }

            eViewStatus viewStatus = fields.Input();

            return new ControllerRequest(new LoginController(), viewStatus, fields);
        }
    }
}
