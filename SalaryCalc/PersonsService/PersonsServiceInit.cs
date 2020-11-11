using InterfacesDefinitions.PersonsServiceInterfaces;
using MyHomeUnity;

namespace PersonsService
{
    internal class PersonsServiceInit : IModuleInit
    {
        public void ClassFactoriesRegistration(IClassFactoryRegister register)
        {
            register.AddFactory(() => (IPersonService)new PersonsService());
        }
    }
}