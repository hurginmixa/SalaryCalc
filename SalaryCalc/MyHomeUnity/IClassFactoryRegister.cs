using System;

namespace MyHomeUnity
{
    public interface IClassFactoryRegister
    {
        void AddFactory<T>(Func<T> method) where T : class;
    }
}