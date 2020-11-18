using InterfacesDefinitions.PersonsServiceInterfaces;
using MyHomeMVC.Controllers;
using MyHomeMVC.Views;
using MyHomeUnity;
using SalaryCalc.Models;
using SalaryCalc.Views;

namespace SalaryCalc.Controllers
{
    class ManagerAddNewPersonController : ControllerBase
    {
        public override ViewRequest Run(ViewResult viewResult)
        {
            if (viewResult.ViewStatus == eViewStatus.Cancel)
            {
                return new ViewRequest<ManagerMainView>();
            }

            var personService = Bootstrapper.Factory.GetInstance<IPersonService>();

            (PersonServiceResult Result, IAddlingPerson AddlingPerson) tuple;
            if ((tuple = personService.GetAddlingPerson(ApplicationData.CurrentData.CurrentSession)).Result != PersonServiceResult.Success)
            {
                return new ViewRequest<ManagerAddNewPersonView>(new ViewInput("Не хватает прав для добавления пользователя", viewResult.Values));
            }

            string firstName = viewResult.Values["FirstName"];
            string lastName = viewResult.Values["LastName"];
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                return new ViewRequest<ManagerAddNewPersonView>(new ViewInput("Имя и Фамилия не могут быть пустыми", viewResult.Values));
            }

            string txtRole = viewResult.Values["Role"];
            if (txtRole != "1" && txtRole != "2" && txtRole != "3")
            {
                return new ViewRequest<ManagerAddNewPersonView>(new ViewInput("Поле Роль содержит не допустимые значение", viewResult.Values));
            }

            Role role = (Role)int.Parse(txtRole);

            (PersonServiceResult Result, IPerson Person) newPersonTuple;
            if ((newPersonTuple = tuple.AddlingPerson.AddNewPerson(firstName, lastName, role)).Result == PersonServiceResult.Success)
            {
                return new ViewRequest<ManagerMainView>();
            }

            string message = newPersonTuple.Result switch
            {
                PersonServiceResult.AlreadyExist => $"{newPersonTuple.Person.FirstName}, {newPersonTuple.Person.LastName} пользователь уже существует",

                _ => "Пользователь не может быть добавлен (внутренняя ошибка)"
            };

            return new ViewRequest<ManagerAddNewPersonView>(new ViewInput(message, viewResult.Values));
        }
    }
}
