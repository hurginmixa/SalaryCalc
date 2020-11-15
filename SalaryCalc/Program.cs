using System;
using System.Text;
using InterfacesDefinitions.PersonsServiceInterfaces;
using MyHomeMVC.Controllers;
using MyHomeUnity;
using SalaryCalc.Controllers;

namespace SalaryCalc
{
    internal static class Program
    {
        public static void Main()
        {
            Bootstrapper.LoadModules("SalaryCalc.xml");

            Console.OutputEncoding = Encoding.UTF8;

            ControllerRequest controllerRequest = new ControllerRequest<LoginController>();

            while (controllerRequest != null)
            {
                controllerRequest = controllerRequest.RunController().RunView();
            }

            Bootstrapper.Factory.GetInstance<IPersonService>().Save();
        }
    }
}
