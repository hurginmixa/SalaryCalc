using System;

namespace SalaryCalc.ViewHelpers.ViewFields
{
    internal class WaitOkField : Field
    {
        private readonly string _text;

        public WaitOkField(int left, int top, int length, string name, string text) : base(left: left, top: top, length: length, name: name)
        {
            _text = text;
        }

        public WaitOkField(int left, int top, string name, string text) : this(left: left, top: top, length: text.Length, name: name, text: text)
        {
            _text = text;
        }

        public override eInputFieldResult Input()
        {
            ViewTools.eInputResult inputResult = ViewTools.WaitToOk(Left, Top, ConsoleColor.Green, _text);

            return Convert(inputResult);
        }

        public override void Draw()
        {
            ViewTools.Txt(left: Left, top: Top, length: Length, text: _text);
        }

        public override string Value => _text;
    }
}