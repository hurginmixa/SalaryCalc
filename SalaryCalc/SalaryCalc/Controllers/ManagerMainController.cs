using System;
using System.Linq;
using SalaryCalc.Views;
using SalaryCalc.Views.ViewFields;

namespace SalaryCalc.Controllers
{
    internal class ManagerMainController : Controller
    {
        public override ViewRequest Run(ViewResult viewResult)
        {
            if (viewResult.InputFieldResult != eInputFieldResult.Ok)
            {
                return new ViewRequest(new ExitView());
            }

            var choose = (viewResult.Fields.List.First(f => f.Name == "Choose").Value ?? "");

            if (choose == "0")
            {
                return new ViewRequest(new ExitView());
            }

            return new ViewRequest(new ManagerMainView());
        }
    }
}