using System;

namespace SalaryCalc.ViewHelpers.ViewFields
{
    internal abstract class TextField : Field
    {
        public TextField(int left, int top, int length, string name, string text) : base(left: left, top: top, length: length, name: name)
        {
            Text = text;
        }

        public override void Draw()
        {
            ViewTools.Txt(left: Left, top: Top, length: Length, text: Text);
        }

        public override string Value => Text;


        protected ViewTools.eInputResult ProtectedInput()
        {
            var newText = ViewTools.Input(left: Left, top: Top, length: Length, prev: Text, color: ConsoleColor.Yellow, inputResult: out ViewTools.eInputResult inputResult);

            if (inputResult != ViewTools.eInputResult.Esc)
            {
                Text = newText;
            }

            return inputResult;
        }

        protected string Text { get ; set ; }
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

            return Convert(inputResult);
        }
    }

    internal class ChooseField: TextField
    {
        public ChooseField(int left, int top, string name) : base(left, top, 1, name, string.Empty)
        {
        }

        public override eInputFieldResult Input()
        {
            return Convert(ProtectedInput());
        }
    }
}