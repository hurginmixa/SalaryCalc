namespace InterfacesDefinitions.PersonsServiceInterfaces
{
    public interface IAddlingPerson
    {
        PersonServiceResult AddNewPerson(string firstName, string lastName, Role role);
    }
}