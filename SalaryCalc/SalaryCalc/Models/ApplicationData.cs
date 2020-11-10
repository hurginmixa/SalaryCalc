using PersonsService;
using SessionsService;

namespace SalaryCalc.Models
{
    class ApplicationData
    {
        private ISession _currentSession;

        static ApplicationData()
        {
            CurrentData = new ApplicationData();
        }

        public static ApplicationData CurrentData { get; }

        public void StartNewSession(IPerson person)
        {
            _currentSession = SessionFactory.NewSession(person);
        }

        public IPerson CurrentPerson => CurrentSession.Person;

        public ISession CurrentSession => _currentSession;
    }
}
