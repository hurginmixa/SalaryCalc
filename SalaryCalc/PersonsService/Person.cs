using InterfacesDefinitions.PersonsServiceInterfaces;

namespace PersonsService
{
    internal class Person : IPerson
    {
        public Person(string firstName, string lastName, Role role)
        {
            FirstName = firstName;
            LastName = lastName;
            Role = role;
        }

        public string FirstName { get; }

        public string LastName { get; }
        
        public Role Role { get; }
    }
}