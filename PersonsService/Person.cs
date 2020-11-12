using AccessToData;
using InterfacesDefinitions.PersonsServiceInterfaces;

namespace PersonsService
{
    internal class Person : IPerson
    {
        public Person(PersonData personData)
        {
            FirstName = personData.FirstName;
            LastName = personData.LastName;
            Role = personData.Role;
        }

        public string FirstName { get; }

        public string LastName { get; }
        
        public Role Role { get; }

        public PersonData GetData => new PersonData() {FirstName = FirstName, LastName = LastName, Role = Role};
    }
}