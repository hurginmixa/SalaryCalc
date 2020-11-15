using System;

namespace SalaryCalc.ViewHelpers.ViewFields
{
    internal abstract class TextField : Field
    {
        private string _text;

        protected TextField(int left, int top, int length, string name, string text) : base(left: left, top: top, length: length, name: name)
        {
            _text = text;
        }

        public override void Draw() => ViewTools.Txt(left: Left, top: Top, length: Length, text: _text);

        public override string Value => _text;

        protected void SetValue(string value) => _text = value;

        protected ViewTools.eInputResult ProtectedInput()
        {
            var newText = ViewTools.Input(left: Left, top: Top, length: Length, prev: _text, color: ConsoleColor.Yellow, inputResult: out ViewTools.eInputResult inputResult);

            if (inputResult != ViewTools.eInputResult.Esc)
            {
                _text = newText;
            }

            return inputResult;
        }
    }

    internal class EditField : TextField
    {
        public EditField(int left, int top, int length, string name, string text) : base(left, top, length, name, text)
        {
        }

        public override eInputFieldResult Input()
        {
            var inputResult = ProtectedInput();
            if (inputResult == ViewTools.eInputResult.Ok)
            {
                inputResult = ViewTools.eInputResult.Tab;
            }

            return inputResult.AsInputFieldResult();
        }
    }

    internal class ChooseField: TextField
    {
        private readonly ChooseConvert _chooseConvert;

        public delegate string ChooseConvert(string src);

        public ChooseField(int left, int top, string name) : this(left: left, top: top, name: name, chooseConvert: s => s)
        {
        }

        public ChooseField(int left, int top, string name, ChooseConvert chooseConvert) : base(left, top, 1, name, string.Empty)
        {
            _chooseConvert = chooseConvert;
        }

        public override eInputFieldResult Input()
        {
            eInputFieldResult inputFieldResult = ProtectedInput().AsInputFieldResult();

            SetValue(_chooseConvert(Value));

            return inputFieldResult;
        }
    }
}