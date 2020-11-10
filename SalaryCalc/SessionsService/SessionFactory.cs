using PersonsService;

namespace SessionsService
{
    public static class SessionFactory
    {
        public static ISession NewSession(IPerson person) => new Session(person);
    }
}
