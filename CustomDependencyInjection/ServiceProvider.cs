using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace CustomDependencyInjection
{
    public class ServiceProvider
    {
        private readonly ServiceContainer container;
        public ServiceProvider(ServiceContainer container)
        {
            this.container = container;

        }

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }
        public object GetService(Type type)
        {
            var service = container.FindService(type);
            var ctor = service.Type.GetConstructors().Single();
            var parameters = ctor.GetParameters();
            if (parameters.Length > 0)
            {
                var serviceParameters = new object[parameters.Length];
                for (int i = 0; i < parameters.Length; i++)
                {
                    serviceParameters[i] = GetService(parameters[i].ParameterType);
                }
                return CreateInstance(service, serviceParameters);
            }
            return CreateInstance(service);
        }

        private object CreateInstance(ServiceDependency dependency, [Optional] object[] parameters)
        {
            if (dependency.IsInitialized && dependency.IsSingleton)
            {
                return dependency.Instance;
            }
            object service = null;
            if (parameters is not null)
            {
                service = Activator.CreateInstance(dependency.Type, parameters);

            }
            else
            {
                service = Activator.CreateInstance(dependency.Type);

            }
            if (dependency.IsSingleton)
            {
                dependency.IsInitialized = true;
                dependency.Instance = service;
            }
            return service;

        }
    }
}