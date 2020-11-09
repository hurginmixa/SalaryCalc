using System;
using SalaryCalc.Controllers;
using SalaryCalc.Views.ViewClasses;
using SalaryCalc.Views.ViewFields;

namespace SalaryCalc.Views
{
    internal class ManagerMainView : ViewBase
    {
        public override ControllerRequestBase View(object model)
        {
            Console.Clear();
            Console.CursorVisible = false;

            ViewTools.Txt(top: 2, left: 3, text: "Главный экран Менеджера");
            ViewTools.Txt(top: 3, left: 3, text: "--------------------------------------------");
            ViewTools.Txt(top: 5, left: 3, text: "(1). Добавить сотрудника");
            ViewTools.Txt(top: 6, left: 3, text: "(2). Просмотреть отчет по всем сотрудникам");
            ViewTools.Txt(top: 7, left: 3, text: "(3). Просмотреть отчет по конкретному сотруднику");
            ViewTools.Txt(top: 8, left: 3, text: "(4). Добавить часы работы");
            ViewTools.Txt(top: 9, left: 3, text: "(5). Выход из программы");

            ViewTools.Txt(top: 11, left: 3, text: "Ваш выбор : ");

            FieldList fields = new FieldList().Add(new ChooseField(top: 11, left: 13, name: "Choose"));

            var inputFieldResult = fields.Input();

            return new ControllerRequest<ManagerMainController>(inputFieldResult, fields);
        }
    }
}