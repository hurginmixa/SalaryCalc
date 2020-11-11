using InterfacesDefinitions.SessionsServiceInterfaces;

namespace InterfacesDefinitions.PersonsServiceInterfaces
{
    public interface IPersonService
    {
        void Save();

        PersonServiceResult GetPerson(string firstName, string lastName, out IPerson person);

        PersonServiceResult GetAddlingPerson(ISession session, out IAddlingPerson addlingPerson);
    }
}