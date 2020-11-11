using System;
using System.Collections.Generic;

namespace MyHomeUnity
{
    internal class ClassFactory : IClassFactory
    {
        internal enum MethodKind
        {
            Factory,
            Singleton,
        }

        private class MethodInfo
        {
            public MethodInfo(Delegate method, MethodKind kind)
            {
                Method = method;
                Kind = kind;
            }

            public Delegate Method { get; }

            public MethodKind Kind { get; }
        }

        public ClassFactory()
        {
            _delegates = new Dictionary<Type, MethodInfo>();
            _singletons = new Dictionary<Type, object>();
        }

        public void AddMethod<T>(Func<T> method, MethodKind methodKind) where T : class
        {
            lock (_delegates)
            {
                _delegates[typeof(T)] = new MethodInfo(method, methodKind);
            }
        }

        public void AddSingleton<T>(T singleton) where T : class
        {
            lock (_delegates)
            {
                _delegates[typeof(T)] = new MethodInfo(method: null, kind: MethodKind.Singleton);
                _singletons[typeof(T)] = singleton;
            }
        }

        public T GetInstance<T>() where T : class
        {
            lock (_delegates)
            {
                var type = typeof(T);

                if (_delegates.TryGetValue(type, out MethodInfo methodInfo))
                {
                    if (methodInfo.Kind == MethodKind.Singleton && _singletons.TryGetValue(type, out object o))
                    {
                        return (T) o;
                    }

                    T instance = ((Func<T>) methodInfo.Method)();

                    if (methodInfo.Kind == MethodKind.Singleton)
                    {
                        _singletons.Add(type, instance);
                    }

                    return instance;
                }

                return null;
            }
        }

        private readonly Dictionary<Type, MethodInfo> _delegates;
        private readonly Dictionary<Type, object> _singletons;
    }
}
