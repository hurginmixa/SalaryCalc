using InterfacesDefinitions.WorkHoursDataServiceInterfaces;
using MyHomeUnity;

namespace WorkHoursDataService
{
    internal class WorkHoursDataServiceInit : IModuleInit
    {
        public void ClassFactoriesRegistration(IClassFactoryRegister register)
        {
            register.AddFactoryForSingleton(() => (IWorkHoursDataService) new WorkHoursDataService());
        }
    }
}
