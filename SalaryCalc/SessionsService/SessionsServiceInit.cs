using InterfacesDefinitions.SessionsServiceInterfaces;
using MyHomeUnity;

namespace SessionsService
{
    internal class SessionsServiceInit : IModuleInit
    {
        public void ClassFactoriesRegistration(IClassFactoryRegister register)
        {
            register.AddFactoryForSingleton(() => (ISessionsService)new SessionsService());
        }
    }
}