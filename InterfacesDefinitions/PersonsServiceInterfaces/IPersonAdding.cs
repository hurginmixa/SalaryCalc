namespace InterfacesDefinitions.PersonsServiceInterfaces
{
    public interface IAddlingPerson
    {
        (PersonServiceResult, IPerson) AddNewPerson(string firstName, string lastName, Role role);
    }
}