namespace InterfacesDefinitions.PersonsServiceInterfaces
{
    public interface IPersonAdding
    {
        (PersonServiceResult, IPerson) AddNewPerson(string firstName, string lastName, Role role);
    }
}