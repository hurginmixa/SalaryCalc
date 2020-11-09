using System;
using System.Text;
using SalaryCalc.Controllers;
using SalaryCalc.Views.ViewClasses;
using SalaryCalc.Views.ViewFields;

namespace SalaryCalc
{
    internal static class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            ControllerRequest controllerRequest = new ControllerRequest(new LoginController(), eViewStatus.None, new FieldList());

            while (controllerRequest != null)
            {
                controllerRequest = controllerRequest.RunController().RunView();
            }
        }
    }
}
