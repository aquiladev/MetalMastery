using Autofac;

namespace MetalMastery.Core.Infrastructure
{
    public interface IDependencyRegistrar
    {
        void Register(ContainerBuilder builder);
    }
}
