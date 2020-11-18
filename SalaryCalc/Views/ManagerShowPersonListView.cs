using System;
using System.Linq;
using InterfacesDefinitions.PersonsServiceInterfaces;
using MyHomeMVC.Controllers;
using MyHomeMVC.Views;
using SalaryCalc.Controllers;
using SalaryCalc.Models;
using SalaryCalc.ViewHelpers;
using SalaryCalc.ViewHelpers.ViewFields;

namespace SalaryCalc.Views
{
    internal class ManagerShowPersonListView : ViewBase
    {
        public override ControllerRequest View(object model)
        {
            Console.Clear();
            Console.CursorVisible = false;

            IPerson currentUser = ApplicationData.CurrentData.CurrentPerson;

            int left = 3;
            int top = 2;

            ViewTools.Txt(top: top++, left: left, text: "Список работников");
            ViewTools.Txt(top: top++, left: left, text: $"Пользователь: {currentUser.FirstName}, {currentUser.LastName}");
            ViewTools.Txt(top: top++, left: left, text: "--------------------------------------------");
            top++;

            ViewTools.Txt(top: top++, left: left, text:"+------+------------------+------------------+-------------+");
            ViewTools.Txt(top: top++, left: left, text:"|  Id  |      Имя         |      Фамилия     |  Должность  |");
            ViewTools.Txt(top: top++, left: left, text:"+------+------------------+------------------+-------------+");

            IPerson[] persons = (IPerson[]) model;

            foreach (var person in persons.OrderBy(p => p.Role).ThenBy(p => p.LastName))
            {
                string role = person.Role switch
                {
                    Role.Worker => "Работник",
                    Role.Manager => "Менеджер",
                    Role.Freelancer => "Фриланстер",
                    _ => throw new ArgumentOutOfRangeException()
                };

                ViewTools.Txt(top: top++, left: left, text:$"| {person.Id,4} | {person.FirstName,-16} | {person.LastName,-16} | {role, -11} |");
            }

            ViewTools.Txt(top: top++, left: left, text:"+------+------------------+------------------+-------------+");


            FieldList fields = new FieldList();
            top++;
            fields.Add(new WaitOkField(top: top++, left: left, name: "Ok", text: "[ Ok ]"));

            eViewStatus viewStatus = fields.Input();

            return new ControllerRequest<ManagerMainController>();
        }
    }
}