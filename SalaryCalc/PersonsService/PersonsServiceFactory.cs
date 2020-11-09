namespace PersonsService
{
    public class PersonsServiceFactory
    {
        private static readonly IPersonService _personService;

        static PersonsServiceFactory()
        {
            _personService = new global::PersonsService.PersonsService();
        }

        public static IPersonService Service() => _personService;
    }
}