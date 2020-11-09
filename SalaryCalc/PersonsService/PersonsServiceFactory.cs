namespace PersonsService
{
    public class PersonsServiceFactory
    {
        private static readonly IPersonService _personService;

        static PersonsServiceFactory()
        {
            _personService = new PersonsService();
        }

        public static IPersonService Service() => _personService;
    }
}