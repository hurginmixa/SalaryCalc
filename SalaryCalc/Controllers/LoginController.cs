using InterfacesDefinitions.PersonsServiceInterfaces;
using MyHomeUnity;
using SalaryCalc.Models;
using SalaryCalc.Views;
using SalaryCalc.Views.ViewClasses;

namespace SalaryCalc.Controllers
{
    internal class LoginController : ControllerBase
    {
        public override ViewRequest Run(ViewResult viewResult)
        {
            if (viewResult.Values.Count() == 0)
            {
                return new ViewRequest<LoginView>();
            }

            if (viewResult.ViewStatus == eViewStatus.Cancel)
            {
                return new ViewRequest<ExitView>();
            }

            IPersonService personService = Bootstrapper.Factory.GetInstance<IPersonService>();

            if (personService.GetPerson(viewResult.Values["FirstName"], viewResult.Values["LastName"], out IPerson person) != PersonServiceResult.Success)
            {
                return new ViewRequest<LoginView>(new ViewInput("Пользователь не найден"));
            }

            ApplicationData.CurrentData.StartNewSession(person);

            return ApplicationData.CurrentData.GetMainViewForCurrentPearson();
        }
    }
}
