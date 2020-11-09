using System;
using System.Collections.Generic;
using SalaryCalc.Views.ViewFields;

namespace SalaryCalc.Views
{
    internal class LoginView
    {
        readonly List<Field> _fields = new List<Field>();

        public LoginView()
        {
            _fields.Add(new TextField(top: 4, left: 13, length: 15, name: "First Name", text: ""));
            _fields.Add(new TextField(top: 5, left: 13, length: 15, name: "Second Name", text: ""));
            _fields.Add(new WaitOkField(top: 6, left: 3, name: "Ok", text: "[ Ok ]"));
        }

        public void View()
        {
            Console.Clear();
            Console.CursorVisible = false;

            ViewTools.Txt(top: 2, left: 3, text: "Добро пожаловать, представтесь пожалуйста");
            ViewTools.Txt(top: 3, left: 3, text: "--------------------------------------------");
            ViewTools.Txt(top: 4, left: 3, text: "Имя     :");
            ViewTools.Txt(top: 5, left: 3, text: "Фамилия :");

            foreach (var field in _fields)
            {
                field.Draw();
            }

            int iCurrentFiend = 0;

            var currentFiend = _fields[iCurrentFiend];

            eInputFieldResult inputFieldResult = currentFiend.Input();

            while (inputFieldResult != eInputFieldResult.Ok && inputFieldResult != eInputFieldResult.Cancel)
            {
                if (inputFieldResult == eInputFieldResult.PrevField)
                {
                    iCurrentFiend = iCurrentFiend > 0 ? iCurrentFiend - 1 : _fields.Count - 1;
                }
                else
                {
                    iCurrentFiend = iCurrentFiend >= _fields.Count - 1 ? 0 : iCurrentFiend + 1;
                }

                currentFiend = _fields[iCurrentFiend];

                inputFieldResult = currentFiend.Input();
            }
        }
    }
}
