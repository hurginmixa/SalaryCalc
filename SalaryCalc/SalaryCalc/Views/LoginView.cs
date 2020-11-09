using System;

namespace SalaryCalc.Views
{
    internal class LoginView
    {
        private class Field
        {
            public Field(int left, int top, int length, string name, string text)
            {
                Left = left;
                Top = top;
                Name = name;
                Text = text;
                Length = length;
            }

            public int Left{ get; }
            public int Top{ get; }
            public int Length { get; }
            public string Name { get; }
            public string Text { get; set; }
        }

        readonly Field[] _fields = new Field[2];

        public LoginView()
        {
            _fields[0] = new Field(top: 4, left:13, length: 15, name: "First Name", text: "");
            _fields[1] = new Field(top: 5, left:13, length: 15, name: "Second Name", text: "");
        }

        public void View()
        {
            Console.Clear();
            Console.CursorVisible = false;

            ViewTools.Txt(top: 2, left: 3, text: "Добро пожаловать, представтесь пожалуйста");
            ViewTools.Txt(top: 3, left: 3, text: "--------------------------------------------");
            ViewTools.Txt(top: 4, left: 3, text: "Имя     :");
            ViewTools.Txt(top: 5, left: 3, text: "Фамилия :");

            int iCurrentFiend = 0;

            var currentFiend = _fields[iCurrentFiend];

            var newText = ViewTools.Input(left: currentFiend.Left, top: currentFiend.Top, length: currentFiend.Length, prev: currentFiend.Text, color: ConsoleColor.Yellow, inputResult: out var inputResult);

            while (inputResult != ViewTools.eInputResult.Esc)
            {
                currentFiend.Text = newText;

                if (inputResult == ViewTools.eInputResult.ShiftTab)
                {
                    iCurrentFiend = iCurrentFiend > 0 ? iCurrentFiend - 1 : _fields.Length - 1;
                }
                else
                {
                    iCurrentFiend = iCurrentFiend >= _fields.Length - 1 ? 0 : iCurrentFiend + 1;
                }

                currentFiend = _fields[iCurrentFiend];

                newText = ViewTools.Input(left: currentFiend.Left, top: currentFiend.Top, length: currentFiend.Length, prev: currentFiend.Text, color: ConsoleColor.Yellow, inputResult: out inputResult);
            }
        }
    }
}
