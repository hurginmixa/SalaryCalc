namespace PersonsService
{
    public interface IPerson
    {
        string FirstName { get; }

        string SecondName { get; }
        
        Role Role { get; }
    }
}