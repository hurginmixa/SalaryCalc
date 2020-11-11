using System;

namespace MyHomeUnity
{
    internal class ClassFactoryRegister : IClassFactoryRegister
    {
        private readonly ClassFactory _classFactory;

        public ClassFactoryRegister(ClassFactory classFactory)
        {
            _classFactory = classFactory;
        }

        public void AddFactory<T>(Func<T> method) where T : class
        {
            _classFactory.AddMethod(method);
        }
    }
}