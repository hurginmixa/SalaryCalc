namespace InterfacesDefinitions.PersonsServiceInterfaces
{
    public interface IPerson
    {
        string FirstName { get; }

        string LastName { get; }
        
        Role Role { get; }
    }
}