using System;
using PersonsService;
using SalaryCalc.Controllers;
using SalaryCalc.Models;
using SalaryCalc.Views.ViewClasses;
using SalaryCalc.Views.ViewFields;

namespace SalaryCalc.Views
{
    class ManagerAddNewPersonView : ViewBase
    {
        public override ControllerRequest View(object model)
        {
            Console.Clear();
            Console.CursorVisible = false;

            IPerson currentUser = ApplicationData.CurrentData.CurrentPerson;

            ViewTools.Txt(top: 2, left: 3, text: "Добавление нового сотрудника");
            ViewTools.Txt(top: 3, left: 3, text: $"Пользователь: {currentUser.FirstName}, {currentUser.LastName}");
            ViewTools.Txt(top: 4, left: 3, text: "--------------------------------------------");

            ViewTools.Txt(top: 6, left: 3, text: "Имя            :");
            ViewTools.Txt(top: 7, left: 3, text: "Фамилия        :");
            ViewTools.Txt(top: 8, left: 3, text: "Роль (1, 2, 3) :");

            FieldList fields = new FieldList()
                .Add(new EditField(top: 6, left: 19, length: 15, name: "FirstName", text: ""))
                .Add(new EditField(top: 7, left: 19, length: 15, name: "LastName", text: ""))
                .Add(new EditField(top: 8, left: 19, length: 15, name: "Role", text: ""))
                .Add(new WaitOkField(top: 9, left: 17, name: "Ok", text: "[ Ok ]"));

            var viewStatus = fields.Input();

            return new ControllerRequest<ManagerAddNewPersonController>(viewStatus, fields.ToResultValueList());
        }
    }
}
