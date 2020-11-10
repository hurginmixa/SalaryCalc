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

            FieldList fields = new FieldList();

            int left = 3;
            int pos = 2;
            ViewTools.Txt(top: pos++, left: left, text: "Добро пожаловать, представтесь пожалуйста");
            ViewTools.Txt(top: pos++, left: left, text: "--------------------------------------------");
            
            ViewTools.Txt(top: pos, left: left, text: "Имя     :");
            fields.Add(new EditField(top: pos++, left: left + 10, length: 15, name: "FirstName", text: ""));

            ViewTools.Txt(top: pos, left: left, text: "Фамилия :");
            fields.Add(new EditField(top: pos++, left: left + 10, length: 15, name: "LastName", text: ""));

            pos++;
            fields.Add(new WaitOkField(top: pos++, left: left, name: "Ok", text: "[ Ok ]"));

            if (model is string message && !string.IsNullOrWhiteSpace(message))
            {
                pos++;
                Console.ForegroundColor = ConsoleColor.Red;
                ViewTools.Txt(top: pos++, left: 3, length: 20, text: message);
                Console.ResetColor();
            }

            eViewStatus viewStatus = fields.Input();

            return new ControllerRequest<LoginController>(viewStatus: viewStatus, valueList: fields.ToResultValueList());
        }
    }
}
