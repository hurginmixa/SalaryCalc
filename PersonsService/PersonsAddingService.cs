using System.Collections.Generic;
using System.Linq;
using AccessToData;
using InterfacesDefinitions.PersonsServiceInterfaces;
using InterfacesDefinitions.SessionsServiceInterfaces;
using MyHomeUnity;

namespace PersonsService
{
    internal class PersonsService : IPersonService, IPersonAdding
    {
        private readonly List<Person> _list = new List<Person>();

        public PersonsService()
        {
            IPersonDataListSerializer serializer = Bootstrapper.Factory.GetInstance<IPersonDataListSerializer>();
            PersonDataList dataList = serializer.Load();

            _list.AddRange(dataList.DataList.Select(p => new Person(p)));
        }

        public void Save()
        {
            IPersonDataListSerializer serializer = Bootstrapper.Factory.GetInstance<IPersonDataListSerializer>();
            serializer.Save(new PersonDataList {DataList = _list.Select(p => p.GetData).ToArray()});
        }

        public (PersonServiceResult Result, IPerson Person) GetPerson(string firstName, string lastName)
        {
            var person = _list.FirstOrDefault(p => p.FirstName == firstName && p.LastName == lastName);

            return (person != null ? PersonServiceResult.Success : PersonServiceResult.PersonIsNotFound, person);
        }

        public (PersonServiceResult, IPersonAdding) GetAddlingPerson(ISession session)
        {
            return session.Person.Role == Role.Manager ? (PersonServiceResult.Success, this) : (PersonServiceResult.AccessDenied, null);
        }

        public (PersonServiceResult, IEnumerable<IPerson>) GetPersonList(ISession session)
        {
            return session.Person.Role != Role.Manager ? (PersonServiceResult.AccessDenied, null) : (PersonServiceResult.Success, _list);
        }

        public (PersonServiceResult, IPerson) AddNewPerson(string firstName, string lastName, Role role)
        {
            (PersonServiceResult Result, IPerson Person) personTuple = GetPerson(firstName, lastName);

            if (personTuple.Result == PersonServiceResult.Success)
            {
                personTuple.Result = PersonServiceResult.AlreadyExist;
                return personTuple;
            }

            int id = _list.Count + 1;
            Person person = new Person(firstName, lastName, role, id);

            _list.Add(person);

            return (PersonServiceResult.Success, person);
        }
    }
}