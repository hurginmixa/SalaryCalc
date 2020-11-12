namespace SalaryCalc.Views.ViewClasses
{
    internal class ResultValue
    {
        public ResultValue(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }

        public string Value { get; }
    }
}