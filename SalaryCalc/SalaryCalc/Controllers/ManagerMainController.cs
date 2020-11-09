using System;
using System.Linq;
using SalaryCalc.Views;
using SalaryCalc.Views.ViewFields;

namespace SalaryCalc.Controllers
{
    internal class ManagerMainController : Controller
    {
        public override ViewResultController Run(ViewResult viewResult)
        {
            if (viewResult.InputFieldResult != eInputFieldResult.Ok)
            {
                return new ExitView().View();
            }

            var choose = (viewResult.Fields.List.First(f => f.Name == "Choose").Value ?? "");

            if (choose == "0")
            {
                return new ExitView().View();
            }

            return new ManagerMainView().View();
        }
    }
}