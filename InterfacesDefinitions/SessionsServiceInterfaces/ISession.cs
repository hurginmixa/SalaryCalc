using InterfacesDefinitions.PersonsServiceInterfaces;

namespace InterfacesDefinitions.SessionsServiceInterfaces
{
    public interface ISession
    {
        IPerson Person { get; }
    }

    public class PersonData1
    {
        public PersonData1()
        {
        }

        public string FirstName;
        
        public string LastName;

        public Role Role;
    }

}