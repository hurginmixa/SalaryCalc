using System;
using System.Collections.Generic;

namespace MyHomeUnity
{
    internal class ClassFactory : IClassFactory
    {
        public ClassFactory()
        {
            _delegates = new Dictionary<Type, Delegate>();
            _singletons = new Dictionary<Type, object>();
        }

        public void AddMethod<T>(Func<T> method) where T : class
        {
            lock (_delegates)
            {
                _delegates[typeof(T)] = method;
            }
        }

        public T GetInstance<T>() where T : class
        {
            lock (_delegates)
            {
                if (_singletons.TryGetValue(typeof(T), out object o))
                {
                    return (T) o;
                }

                if (_delegates.TryGetValue(typeof(T), out Delegate method))
                {
                    T instance = ((Func<T>) method)();

                    _singletons.Add(typeof(T), instance);

                    return instance;
                }

                return null;
            }
        }

        private readonly Dictionary<Type, Delegate> _delegates;
        private readonly Dictionary<Type, object> _singletons;
    }
}
