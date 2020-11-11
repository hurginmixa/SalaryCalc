using InterfacesDefinitions.PersonsServiceInterfaces;
using MyHomeUnity;

namespace PersonsService
{
    internal class PersonsServiceInit : IModuleInit
    {
        public void ClassFactoriesRegistration(IClassFactoryRegister register)
        {
            register.AddFactoryForSingleton(() => (IPersonService)new PersonsService());
        }
    }
}