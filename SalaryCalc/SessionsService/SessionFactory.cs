using InterfacesDefinitions.PersonsServiceInterfaces;
using InterfacesDefinitions.SessionsServiceInterfaces;

namespace SessionsService
{
    public static class SessionFactory
    {
        public static ISession NewSession(IPerson person) => new Session(person);
    }
}
