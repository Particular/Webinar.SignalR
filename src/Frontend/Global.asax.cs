namespace Frontend
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Autofac;
    using Autofac.Integration.SignalR;
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
                .ConnectionString("host=lab-linux;username=marcin;password=marcin");
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.EnableInstallers();

            Bus.Create(configuration).Start();

            GlobalHost.DependencyResolver = new AutofacDependencyResolver(container);
        }
    }
}