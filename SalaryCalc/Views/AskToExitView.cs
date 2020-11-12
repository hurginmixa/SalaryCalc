using System;
using SalaryCalc.Controllers;
using SalaryCalc.Views.ViewClasses;
using SalaryCalc.Views.ViewFields;

namespace SalaryCalc.Views
{
    internal class AskToExitView : ViewBase
    {
        public override ControllerRequest View(object model)
        {
            Console.Clear();
            Console.CursorVisible = false;

            ViewTools.Txt(top: 2, left: 3, text: "Вы хотите выйти из программы?");
            ViewTools.Txt(top: 3, left: 3, text: "--------------------------------------------");

            FieldList fieldList = new FieldList();
            fieldList.Add(new WaitOkField(top: 5, left: 3, name: "Ok", text: "[ Ok ]"));

            eViewStatus viewStatus = fieldList.Input();

            return new ControllerRequest<AskToExitController>(viewStatus, fieldList.ToResultValueList());
        }
    }
}