using AccessToData;
using MyHomeUnity;

namespace JsonSerializing
{
    class JsonSerializingInit : IModuleInit
    {
        public void ClassFactoriesRegistration(IClassFactoryRegister register)
        {
            register.AddFactory(() => (IPersonDataListSerializer) new PersonDataListSerializer());
        }
    }
}
