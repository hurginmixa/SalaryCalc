using System;
using SalaryCalc.Views;

namespace SalaryCalc.Controllers
{
    internal abstract class ControllerBase
    {
        public abstract ViewRequestBase Run(ViewResult viewResult);
    }
}
