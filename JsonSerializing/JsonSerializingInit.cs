using AccessToData;
using MyHomeUnity;

namespace JsonSerializingService
{
    class JsonSerializingInit : IModuleInit
    {
        public void ClassFactoriesRegistration(IClassFactoryRegister register)
        {
            register.AddFactory(() => (IPersonDataListSerializer) new PersonDataListSerializer());
        }
    }
}
