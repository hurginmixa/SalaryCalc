using System;

namespace SalaryCalc.Views.ViewFields
{
    internal  class TextField : Field
    {
        private string _text;

        public TextField(int left, int top, int length, string name, string text) : base(left:left, top:top, length:length, name:name)
        {
            _text = text;
        }

        public override void Draw()
        {
            ViewTools.Txt(left: Left, top: Top, length: Length, text: _text);
        }

        public override eInputFieldResult Input()
        {
            var newText = ViewTools.Input(left: Left, top: Top, length: Length, prev: _text, color: ConsoleColor.Yellow, inputResult: out var inputResult);

            if (inputResult != ViewTools.eInputResult.Esc)
            {
                _text = newText;
            }

            if (inputResult == ViewTools.eInputResult.Ok)
            {
                inputResult = ViewTools.eInputResult.Tab;
            }

            return Convert(inputResult);
        }
    }
}