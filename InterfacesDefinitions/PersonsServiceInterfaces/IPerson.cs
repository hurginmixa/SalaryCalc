namespace InterfacesDefinitions.PersonsServiceInterfaces
{
    public interface IPerson
    {
        int Id { get; }

        string FirstName { get; }

        string LastName { get; }
        
        Role Role { get; }
    }
}