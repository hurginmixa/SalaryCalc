﻿using System.Collections.Generic;
using System.Linq;
using AccessToData;
using InterfacesDefinitions.PersonsServiceInterfaces;
using InterfacesDefinitions.SessionsServiceInterfaces;

namespace PersonsService
{
    internal class PersonsService : IPersonService, IAddlingPerson
    {
        private readonly List<Person> _list = new List<Person>();

        public PersonsService()
        {
            PersonDataList dataList = PersonDataListSerializer.Load();

            _list.AddRange(dataList.DataList.Select(p => new Person(p)));
        }

        public void Save()
        {
            PersonDataListSerializer.Save(new PersonDataList {DataList = _list.Select(p => p.GetData).ToArray()});
        }

        public PersonServiceResult GetPerson(string firstName, string lastName, out IPerson person)
        {
            person = _list.FirstOrDefault(p => p.FirstName == firstName && p.LastName == lastName);

            return person != null ? PersonServiceResult.Success : PersonServiceResult.PersonIsNotFound;
        }

        public PersonServiceResult GetAddlingPerson(ISession session, out IAddlingPerson addlingPerson)
        {
            if (session.Person.Role == Role.Manager)
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

            _list.Add(new Person(new PersonData {FirstName = firstName, LastName = lastName, Role = role}));

            return PersonServiceResult.Success;
        }
    }
}