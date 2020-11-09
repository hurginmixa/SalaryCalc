using System;
using SalaryCalc.Views;
using SalaryCalc.Views.ViewClasses;

namespace SalaryCalc.Controllers
{
    internal abstract class ControllerBase
    {
        public abstract ViewRequestBase Run(ViewResult viewResult);
    }
}
