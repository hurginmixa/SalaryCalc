using System;
using PersonsService;
using SalaryCalc.Controllers;
using SalaryCalc.Models;
using SalaryCalc.Views.ViewClasses;
using SalaryCalc.Views.ViewFields;

namespace SalaryCalc.Views
{
    internal class ManagerMainView : ViewBase
    {
        public override ControllerRequest View(object model)
        {
            Console.Clear();
            Console.CursorVisible = false;

            IPerson currentUser = ApplicationData.CurrentData.CurrentPerson;

            int left = 3;
            int pos = 2;
            ViewTools.Txt(top: pos++, left: left, text: "Главный экран Менеджера");
            ViewTools.Txt(top: pos++, left: left, text: $"Пользователь: {currentUser.FirstName}, {currentUser.LastName}");
            ViewTools.Txt(top: pos++, left: left, text: "--------------------------------------------");
            pos++;
            ViewTools.Txt(top: pos++, left: left, text: "(1). Добавить сотрудника");
            ViewTools.Txt(top: pos++, left: left, text: "(2). Просмотреть отчет по всем сотрудникам");
            ViewTools.Txt(top: pos++, left: left, text: "(3). Просмотреть отчет по конкретному сотруднику");
            ViewTools.Txt(top: pos++, left: left, text: "(4). Добавить часы работы");
            ViewTools.Txt(top: pos++, left: left, text: "(5). Выход из программы");
            ViewTools.Txt(top: pos++, left: left, text: "(6). Сменить пользователя");
            pos++;
            ViewTools.Txt(top: pos, left: left, text: "Ваш выбор : ");
            FieldList fields = new FieldList().Add(new ChooseField(top: pos++, left: left + 13, name: "Choose"));

            var inputFieldResult = fields.Input();

            return new ControllerRequest<ManagerMainController>(inputFieldResult, fields.ToResultValueList());
        }
    }
}