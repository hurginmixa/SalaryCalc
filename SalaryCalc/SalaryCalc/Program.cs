using System;
using System.Text;
using PersonsService;
using SalaryCalc.Controllers;
using SalaryCalc.Views;
using SalaryCalc.Views.ViewFields;

namespace SalaryCalc
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            IPersonService personService = PersonsService.PersonsServiceFactory.Service();

            Console.OutputEncoding = Encoding.UTF8;

            ControllerRequest controllerRequest = new ControllerRequest(eInputFieldResult.Ok, new FieldList(), new LoginController());

            while (controllerRequest != null)
            {
                var viewRequest = controllerRequest.Controller.Run(controllerRequest.ViewResult);

                controllerRequest = viewRequest.View.View(model: viewRequest.Model);
            }
        }
    }
}
