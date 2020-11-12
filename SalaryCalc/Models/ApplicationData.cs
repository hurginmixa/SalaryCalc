using InterfacesDefinitions.PersonsServiceInterfaces;
using InterfacesDefinitions.SessionsServiceInterfaces;
using MyHomeMVC.Controllers;
using MyHomeUnity;
using SalaryCalc.Controllers;
using SalaryCalc.Views;

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
            _currentSession = Bootstrapper.Factory.GetInstance<ISessionsService>().NewSessionForPerson(person);
        }

        public IPerson CurrentPerson => CurrentSession.Person;

        public ISession CurrentSession => _currentSession;

        public ViewRequest GetMainViewForCurrentPearson()
        {
            var person = CurrentSession.Person;

            if (person.Role == Role.Manager)
            {
                return new ViewRequest<ManagerMainView>();
            }

            return new ViewRequest<UserMainView>();
        }
    }
}
