namespace PersonsService
{
    public interface IAddlingPerson
    {
        PersonServiceResult AddNewPerson(string firstName, string lastName, Role role);
    }
}