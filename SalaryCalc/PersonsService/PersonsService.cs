using System.Collections.Generic;
using System.Linq;

namespace PersonsService
{
    internal class PersonsService : IPersonService, IAddlingPerson
    {
        private readonly List<Person> _list = new List<Person>();

        public PersonsService()
        {
            AddNewPerson("a", "b", Role.Manager);
        }

        public void Save()
        {
        }

        public PersonServiceResult GetPerson(string firstName, string lastName, out IPerson person)
        {
            person = _list.FirstOrDefault(p => p.FirstName == firstName && p.LastName == lastName);

            return person != null ? PersonServiceResult.Success : PersonServiceResult.PersonIsNotFound;
        }

        public PersonServiceResult GetAddlingPerson(IPerson actor, out IAddlingPerson addlingPerson)
        {
            if (actor.Role == Role.Manager)
            {
                addlingPerson = this;
                return PersonServiceResult.Success;
            }

            addlingPerson = null;
            return PersonServiceResult.AccessDenied;
        }

        public PersonServiceResult AddNewPerson(string firstName, string lastName, Role role)
        {
            if (GetPerson(firstName, lastName, out _) == PersonServiceResult.Success)
            {
                return PersonServiceResult.AlreadyExist;
            }

            Person person = new Person(firstName, lastName, role);
            _list.Add(person);

            return PersonServiceResult.Success;
        }
    }
}