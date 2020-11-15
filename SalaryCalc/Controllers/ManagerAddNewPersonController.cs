﻿using InterfacesDefinitions.PersonsServiceInterfaces;
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

            if (personService.GetAddlingPerson(ApplicationData.CurrentData.CurrentSession, out var addlingPerson) != PersonServiceResult.Success)
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

            PersonServiceResult addingResult;
            if ((addingResult = addlingPerson.AddNewPerson(firstName, lastName, role)) != PersonServiceResult.Success)
            {
                string message;

                switch (addingResult)
                {
                    default:
                        message = "Пользователь не может быть добавлен (внутренняя ошибка)";
                        break;

                    case PersonServiceResult.AlreadyExist:
                        message = "Такой пользователь уже существует";
                        break;
                }

                return new ViewRequest<ManagerAddNewPersonView>(new ViewInput(message, viewResult.Values));

            }

            return new ViewRequest<ManagerMainView>();
        }
    }
}