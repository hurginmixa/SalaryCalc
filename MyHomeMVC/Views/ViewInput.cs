namespace MyHomeMVC.Views
{
    public class ViewInput
    {
        public ViewInput(string message, ResultValueList values)
        {
            Message = message;
            Values = values;
        }

        public ViewInput(string message) : this(message, new ResultValueList())
        {
        }

        public string Message { get; }

        public ResultValueList Values { get; }
    }
}
