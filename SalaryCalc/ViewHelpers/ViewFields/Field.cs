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
    }
}