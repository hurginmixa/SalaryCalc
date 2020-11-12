using System;

namespace MyHomeUnity
{
    public interface IClassFactoryRegister
    {
        void AddFactory<T>(Func<T> method) where T : class;

        void AddFactoryForSingleton<T>(Func<T> method) where T : class;

        void AddSingleton<T>(T singleton) where T : class;
    }
}