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
            ViewTools.Txt(top: pos++, left: left, text: "(2). Просмотреть список сотрудников");
            ViewTools.Txt(top: pos++, left: left, text: "(3). Просмотреть отчет по всем сотрудникам");
            ViewTools.Txt(top: pos++, left: left, text: "(4). Просмотреть отчет по конкретному сотруднику");
            ViewTools.Txt(top: pos++, left: left, text: "(5). Добавить часы работы");
            ViewTools.Txt(top: pos++, left: left, text: "(6). Сменить пользователя");
            ViewTools.Txt(top: pos++, left: left, text: "(7). Выход из программы");
            pos++;
            ViewTools.Txt(top: pos, left: left, text: "Ваш выбор : ");
            FieldList fields = new FieldList().Add(new ChooseField(top: pos++, left: left + 13, name: "Choose", chooseConvert: ChooseConvert));

            eViewStatus inputFieldResult = fields.Input();

            return new ControllerRequest<ManagerMainController>(inputFieldResult, fields.ToResultValueList());
        }

        private static string ChooseConvert(string src)
        {
            return src switch
            {
                "1" => ManagerMainController.eAction.AddNewPerson.ToString(),

                "2" => ManagerMainController.eAction.ShowWorkerList.ToString(),

                "7" => ManagerMainController.eAction.ExitProgram.ToString(),
                
                "6" => ManagerMainController.eAction.ChangeUser.ToString(),
                
                _ => ManagerMainController.eAction.None.ToString()
            };
        }
    }
}