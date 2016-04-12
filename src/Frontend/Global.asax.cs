namespace Frontend
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Autofac;
    using Autofac.Integration.SignalR;
    using Backend;
    using Microsoft.AspNet.SignalR;
    using NServiceBus;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureAndStartTheBus();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void ConfigureAndStartTheBus()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterHubs(typeof(MvcApplication).Assembly);

            IContainer container = builder.Build();

            BusConfiguration configuration = new BusConfiguration();
            configuration.UseContainer<AutofacBuilder>(c => c.ExistingLifetimeScope(container));
            configuration.UseTransport<RabbitMQTransport>()
                .ConnectionString(RabbitMqConnectionString.Value);
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.EnableInstallers();

            bus = Bus.Create(configuration);
            bus.Start();

            GlobalHost.DependencyResolver = new AutofacDependencyResolver(container);
        }

        protected void Application_End()
        {
            bus.Dispose();
        }

        IStartableBus bus;
    }
}