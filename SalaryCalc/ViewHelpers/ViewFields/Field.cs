using System;

namespace SalaryCalc.ViewHelpers.ViewFields
{
    internal abstract class Field
    {
        protected Field(int left, int top, int length, string name)
        {
            Left = left;
            Top = top;
            Length = length;
            Name = name;
        }

        public abstract eInputFieldResult Input();

        public abstract void Draw();

        protected int Left { get; }

        protected int Top { get; }

        protected int Length { get; }

        public string Name { get; }

        public abstract string Value { get; }

        protected static eInputFieldResult Convert(ViewTools.eInputResult src)
        {
            switch (src)
            {
                case ViewTools.eInputResult.Ok:
                    return eInputFieldResult.Ok;

                case ViewTools.eInputResult.Tab:
                    return eInputFieldResult.NextField;

                case ViewTools.eInputResult.ShiftTab:
                    return eInputFieldResult.PrevField;

                case ViewTools.eInputResult.Esc:
                    return eInputFieldResult.Cancel;

                default:
                    throw new ArgumentOutOfRangeException(nameof(src), src, null);
            }
        }
    }
}