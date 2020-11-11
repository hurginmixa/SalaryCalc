using InterfacesDefinitions.PersonsServiceInterfaces;

namespace InterfacesDefinitions.SessionsServiceInterfaces
{
    public interface ISessionsService
    {
        public ISession NewSessionForPerson(IPerson person);
    }
}