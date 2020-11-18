using AccessToData;
using InterfacesDefinitions.PersonsServiceInterfaces;

namespace PersonsService
{
    internal class Person : IPerson
    {
        public Person(string firstName, string lastName, Role role, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            Id = id;
        }

        public Person(PersonData personData)
        {
            FirstName = personData.FirstName;
            LastName = personData.LastName;
            Role = personData.Role;
            Id = personData.Id;
        }

        public string FirstName { get; }

        public string LastName { get; }
        
        public Role Role { get; }
        
        public int Id { get; }

        public PersonData GetData => new PersonData {FirstName = FirstName, LastName = LastName, Role = Role, Id = Id};
    }
}