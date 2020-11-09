namespace PersonsService
{
    public interface IPersonService
    {
        void Save();

        PersonServiceResult GetPerson(string firstName, string lastName, out IPerson person);

        PersonServiceResult AddNewPerson(string firstName, string lastName, Role role);
    }
}