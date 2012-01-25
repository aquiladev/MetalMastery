using Autofac;
using Autofac.Integration.Mvc;
using MetalMastery.Core.Data;
using MetalMastery.Core.Infrastructure;
using MetalMastery.Data;

namespace MetalMastery.Web
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerHttpRequest();
        }
    }
}
