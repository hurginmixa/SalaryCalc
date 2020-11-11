using InterfacesDefinitions.SessionsServiceInterfaces;
using MyHomeUnity;

namespace SessionsService
{
    internal class SessionFactoryInit : IModuleInit
    {
        public void ClassFactoriesRegistration(IClassFactoryRegister register)
        {
            register.AddFactory(() => (ISessionsService)new SessionsService());
        }
    }
}