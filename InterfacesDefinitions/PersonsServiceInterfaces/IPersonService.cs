using System.Collections.Generic;
using InterfacesDefinitions.SessionsServiceInterfaces;

namespace InterfacesDefinitions.PersonsServiceInterfaces
{
    public interface IPersonService
    {
        void Save();

        (PersonServiceResult Result, IPerson Person) GetPerson(string firstName, string lastName);

        (PersonServiceResult Result, IAddlingPerson AddlingPerson) GetAddlingPerson(ISession session);

        (PersonServiceResult Result, IEnumerable<IPerson> PersonList) GetPersonList(ISession session);
    }
}