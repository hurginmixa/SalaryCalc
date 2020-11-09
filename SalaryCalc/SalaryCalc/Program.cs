using System;
using System.Text;
using PersonsService;

namespace SalaryCalc
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            IPersonService personService = PersonsService.PersonsServiceFactory.Service();

            Console.OutputEncoding = Encoding.UTF8;
            Console.Clear();

            ViewTools.Txt(left: 3, top: 2, text: "+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
            ViewTools.Prompt(left: 3, top: 2, length: 10, prev: "Name", prompt: "Enter Name : ", inputResult: out var inputResult);

            Console.WriteLine();
            Console.WriteLine(inputResult);
        }
    }
}
