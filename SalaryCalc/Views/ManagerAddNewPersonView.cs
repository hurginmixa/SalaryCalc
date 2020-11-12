using System;
using InterfacesDefinitions.PersonsServiceInterfaces;
using MyHomeMVC.Controllers;
using MyHomeMVC.Views;
using SalaryCalc.Controllers;
using SalaryCalc.Models;
using SalaryCalc.ViewHelpers;
using SalaryCalc.ViewHelpers.ViewFields;

namespace SalaryCalc.Views
{
    class ManagerAddNewPersonView : ViewBase
    {
        public override ControllerRequest View(object model)
        {
            ViewInput input = (ViewInput) model;

            Console.Clear();
            Console.CursorVisible = false;

            IPerson currentUser = ApplicationData.CurrentData.CurrentPerson;

            FieldList fields = new FieldList();

            int left = 3;
            int top = 2;

            ViewTools.Txt(top: top++, left: left, text: "Добавление нового сотрудника");
            ViewTools.Txt(top: top++, left: left, text: $"Пользователь: {currentUser.FirstName}, {currentUser.LastName}");
            ViewTools.Txt(top: top++, left: left, text: "--------------------------------------------");
            top++;
            ViewTools.Txt(top: top, left: left, text: "Имя            :");
            fields.Add(new EditField(top: top++, left: left + 16, length: 15, name: "FirstName", text: input?.Values["FirstName"] ?? ""));

            ViewTools.Txt(top: top, left: left, text: "Фамилия        :");
            fields.Add(new EditField(top: top++, left: left + 16, length: 15, name: "LastName", text: input?.Values["LastName"] ?? ""));

            ViewTools.Txt(top: top, left: left, text: "Роль (1, 2, 3) :");
            fields.Add(new EditField(top: top++, left: left + 16, length: 1, name: "Role", text: input?.Values["Role"] ?? ""));

            top++;
            fields.Add(new WaitOkField(top: top++, left: left, name: "Ok", text: "[ Ok ]"));

            if (!string.IsNullOrWhiteSpace(input?.Message))
            {
                top++;
                Console.ForegroundColor = ConsoleColor.Red;
                ViewTools.Txt(top: top++, left: left, text: input.Message);
                Console.ResetColor();
            }

            var viewStatus = fields.Input();

            return new ControllerRequest<ManagerAddNewPersonController>(viewStatus, fields.ToResultValueList());
        }
    }
}
