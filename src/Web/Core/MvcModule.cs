using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;

namespace Web.Core
{
    public class MvcModule : IModule
    {
        private readonly ContainerBuilder builder = new ContainerBuilder();

        public void Configure(IComponentRegistry registry)
        {
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.Update(registry);
        }
    }
}