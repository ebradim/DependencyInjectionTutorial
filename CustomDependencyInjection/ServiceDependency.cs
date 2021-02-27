using System;

namespace CustomDependencyInjection
{
    public class ServiceDependency
    {
        public ServiceDependency(Type type, bool isSingleton)
        {
            Type = type;
            IsSingleton = isSingleton;
        }
        public bool IsSingleton { get; set; }
        public bool IsInitialized { get; set; }
        public object Instance { get; set; }
        public Type Type { get; set; }
    }
}