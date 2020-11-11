using System;
using System.Text;
using MyHomeUnity;
using SalaryCalc.Controllers;
using SalaryCalc.Views.ViewClasses;

namespace SalaryCalc
{
    internal static class Program
    {
        public static void Main()
        {
            Bootstrapper.LoadModules("SalaryCalc.xml");

            Console.OutputEncoding = Encoding.UTF8;

            ControllerRequest controllerRequest = new ControllerRequest<LoginController>(eViewStatus.None, new ResultValueList());

            while (controllerRequest != null)
            {
                controllerRequest = controllerRequest.RunController().RunView();
            }
        }
    }
}
