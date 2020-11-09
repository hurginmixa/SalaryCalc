using System;
using SalaryCalc.Views;

namespace SalaryCalc.Controllers
{
    internal abstract class Controller
    {
        public abstract ViewResultController Run(ViewResult viewResult);
    }
}
