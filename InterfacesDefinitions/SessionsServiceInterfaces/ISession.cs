using InterfacesDefinitions.PersonsServiceInterfaces;

namespace InterfacesDefinitions.SessionsServiceInterfaces
{
    public interface ISession
    {
        IPerson Person { get; }
    }
}