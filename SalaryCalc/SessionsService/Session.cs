using PersonsService;

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