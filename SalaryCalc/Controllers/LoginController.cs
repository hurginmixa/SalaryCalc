using InterfacesDefinitions.PersonsServiceInterfaces;
using MyHomeMVC.Controllers;
using MyHomeMVC.Views;
using MyHomeUnity;
using SalaryCalc.Models;
using SalaryCalc.Views;

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
                if (ApplicationData.CurrentData.CurrentSession?.IsSessionOpen ?? false)
                {
                    return ApplicationData.CurrentData.GetMainViewForCurrentPearson();
                }

                return new ViewRequest<ExitView>();
            }

            IPersonService personService = Bootstrapper.Factory.GetInstance<IPersonService>();

            (PersonServiceResult Result, IPerson Person) personTuple = personService.GetPerson(viewResult.Values["FirstName"], viewResult.Values["LastName"]);

            if (personTuple.Result != PersonServiceResult.Success)
            {
                return new ViewRequest<LoginView>(new ViewInput(message: "Пользователь не найден"));
            }

            ApplicationData.CurrentData.StartNewSession(personTuple.Person);

            return ApplicationData.CurrentData.GetMainViewForCurrentPearson();
        }
    }
}
