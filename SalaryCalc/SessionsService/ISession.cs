using PersonsService;

namespace SessionsService
{
    public interface ISession
    {
        IPerson Person { get; }
    }
}