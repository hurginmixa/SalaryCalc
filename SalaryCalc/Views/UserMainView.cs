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
    internal class UserMainView : ViewBase
    {
        public override ControllerRequest View(object model)
        {
            Console.Clear();
            Console.CursorVisible = false;

            IPerson currentUser = ApplicationData.CurrentData.CurrentPerson;

            int left = 3;
            int pos = 2;
            ViewTools.Txt(top: pos++, left: left, text: "Главный экран пользователя");
            ViewTools.Txt(top: pos++, left: left, text: $"Пользователь: {currentUser.FirstName}, {currentUser.LastName}");
            ViewTools.Txt(top: pos++, left: left, text: "--------------------------------------------");
            pos++;
            ViewTools.Txt(top: pos++, left: left, text: "(1). Добавить часы работы");
            ViewTools.Txt(top: pos++, left: left, text: "(2). Выход из программы");
            ViewTools.Txt(top: pos++, left: left, text: "(3). Сменить пользователя");
            pos++;
            ViewTools.Txt(top: pos, left: left, text: "Ваш выбор : ");
            FieldList fields = new FieldList().Add(new ChooseField(top: pos++, left: left + 13, name: "Choose", chooseConvert: ChooseConvert));

            eViewStatus inputFieldResult = fields.Input();

            return new ControllerRequest<UserMainController>(inputFieldResult, fields.ToResultValueList());
        }

        private string ChooseConvert(string src)
        {
            switch (src)
            {
                case "1":
                    return UserMainController.eAction.AddWorkTime.ToString();

                case "2":
                    return UserMainController.eAction.Exit.ToString();

                case "3":
                    return UserMainController.eAction.ChangeUser.ToString();

                default:
                    return UserMainController.eAction.None.ToString();
            }
        }
    }
}