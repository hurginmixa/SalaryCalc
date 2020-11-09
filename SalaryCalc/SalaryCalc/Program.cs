using System;
using System.Text;
using PersonsService;
using SalaryCalc.Views;

namespace SalaryCalc
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            IPersonService personService = PersonsService.PersonsServiceFactory.Service();

            Console.OutputEncoding = Encoding.UTF8;
            Console.Clear();

            new LoginView().View();
        }
    }
}
