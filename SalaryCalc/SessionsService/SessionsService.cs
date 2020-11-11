using InterfacesDefinitions.PersonsServiceInterfaces;
using InterfacesDefinitions.SessionsServiceInterfaces;

namespace SessionsService
{
    internal class SessionsService : ISessionsService
    {
        public ISession NewSessionForPerson(IPerson person) => new Session(person);
    }
}
