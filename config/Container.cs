using System;
using System.Collections.Generic;
using Speedometer.Dispatchers;

namespace Speedometer.config
{
    public class Container
    {
        private static Container _container;

        private readonly Dictionary<Type, object> registry = new Dictionary<Type, object>();

        public static Container GetContainer()
        {
            return _container ?? (_container = new Container());
        }

        public void Register<TService>(object service)
        {
            registry.Add(typeof(TService), service);
        }

        public object Get(Type service)
        {
            if (registry.ContainsKey(service))
            {
                registry.TryGetValue(service, out var value);

                return value;
            }

            throw new InvalidOperationException("None of objects register for " + service);
        }
    }
}