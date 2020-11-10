using PersonsService;
using SalaryCalc.Models;
using SalaryCalc.Views;
using SalaryCalc.Views.ViewClasses;
using SalaryCalc.Views.ViewFields;

namespace SalaryCalc.Controllers
{
    internal class LoginController : ControllerBase
    {
        public override ViewRequestBase Run(ViewResult viewResult)
        {
            if (viewResult.Fields.Count() == 0)
            {
                return new ViewRequest<LoginView>();
            }

            if (viewResult.ViewStatus == eViewStatus.Cancel)
            {
                return new ViewRequest<ExitView>();
            }

            IPersonService personService = PersonsServiceFactory.Service();

            if (personService.GetPerson(viewResult.Fields["FirstName"].Value, viewResult.Fields["LastName"].Value, out IPerson person) != PersonServiceResult.Success)
            {
                return new ViewRequest<LoginView>("User not found");
            }

            ApplicationData.CurrentData.StartNewSession(person);

            if (person.Role == Role.Manager)
            {
                return new ViewRequest<ManagerMainView>();
            }

            return new ViewRequest<UserMainView>();
        }
    }
}
