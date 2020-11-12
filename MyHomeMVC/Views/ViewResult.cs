namespace MyHomeMVC.Views
{
    public class ViewResult
    {
        public ViewResult(eViewStatus viewStatus, ResultValueList values)
        {
            ViewStatus = viewStatus;
            Values = values;
        }

        public eViewStatus ViewStatus { get; }

        public ResultValueList Values { get; }
    }
}