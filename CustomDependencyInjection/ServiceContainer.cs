using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomDependencyInjection
{
    public class ServiceContainer
    {
        private ICollection<ServiceDependency> _container;
        public ServiceContainer()
        {
            this._container = new List<ServiceDependency>();
        }
        public void AddSingleton<T>()
        {
            _container.Add(new ServiceDependency(typeof(T), true));
        }
        /// <summary>
        /// or Transient
        /// </summary>
        /// <typeparam name="T">Service</typeparam>
        public void AddScoped<T>()
        {
            _container.Add(new ServiceDependency(typeof(T), false));
        }
        public ServiceDependency FindService(Type type)
        {
            return _container.First(x => x.Type.Name == type.Name);
        }
    }
}