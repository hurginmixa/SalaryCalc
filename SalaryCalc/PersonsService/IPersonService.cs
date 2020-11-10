namespace PersonsService
{
    public interface IPersonService
    {
        void Save();

        PersonServiceResult GetPerson(string firstName, string lastName, out IPerson person);

        PersonServiceResult GetAddlingPerson(IPerson actor, out IAddlingPerson addlingPerson);
    }
}