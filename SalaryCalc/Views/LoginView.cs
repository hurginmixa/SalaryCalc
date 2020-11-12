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
            ViewInput input = (ViewInput) model;

            Console.Clear();
            Console.CursorVisible = false;

            FieldList fields = new FieldList();

            int left = 3;
            int top = 2;
            ViewTools.Txt(top: top++, left: left, text: "Добро пожаловать, представьтесь пожалуйста");
            ViewTools.Txt(top: top++, left: left, text: "--------------------------------------------");
            
            ViewTools.Txt(top: top, left: left, text: "Имя     :");
            fields.Add(new EditField(top: top++, left: left + 10, length: 15, name: "FirstName", text: ""));

            ViewTools.Txt(top: top, left: left, text: "Фамилия :");
            fields.Add(new EditField(top: top++, left: left + 10, length: 15, name: "LastName", text: ""));

            top++;
            fields.Add(new WaitOkField(top: top++, left: left, name: "Ok", text: "[ Ok ]"));

            if (!string.IsNullOrWhiteSpace(input?.Message))
            {
                top++;
                Console.ForegroundColor = ConsoleColor.Red;
                ViewTools.Txt(top: top++, left: 3, length: 20, text: input.Message);
                Console.ResetColor();
            }

            eViewStatus viewStatus = fields.Input();

            return new ControllerRequest<LoginController>(viewStatus: viewStatus, valueList: fields.ToResultValueList());
        }
    }
}
