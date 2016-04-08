namespace Frontend
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Autofac;
    using Autofac.Integration.Mvc;
    using NServiceBus;
    using NServiceBus.Logging;

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

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            IContainer container = builder.Build();

            BusConfiguration configuration = new BusConfiguration();
            configuration.UseContainer<AutofacBuilder>(c => c.ExistingLifetimeScope(container));
            configuration.UseTransport<RabbitMQTransport>()
                .ConnectionString("host=lab-linux;username=marcin;password=marcin");
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.EnableInstallers();

            LogManager.Use<DefaultFactory>().Level(LogLevel.Debug);

            Bus.Create(configuration).Start();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}