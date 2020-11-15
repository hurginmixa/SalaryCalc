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

        public IPerson Person { get; private set; }

        public bool IsSessionOpen => Person != null;

        public void Exit()
        {
            Person = null;
        }
    }
}