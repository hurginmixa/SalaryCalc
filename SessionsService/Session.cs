using InterfacesDefinitions.PersonsServiceInterfaces;
using InterfacesDefinitions.SessionsServiceInterfaces;

namespace SessionsService
{
    internal class Session : ISession
    {
        public Session(IPerson person)
        {
            Person = person;
        }

        public IPerson Person { get; }
    }
}