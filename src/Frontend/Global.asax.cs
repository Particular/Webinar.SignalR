namespace Frontend
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using NServiceBus;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigureAndStartTheBus();
        }

        void ConfigureAndStartTheBus()
        {
            BusConfiguration configuration = new BusConfiguration();
            configuration.UseTransport<RabbitMQTransport>()
                .ConnectionString("host=lab-linux;username=marcin;password=marcin");
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.EnableInstallers();
            Bus.Create(configuration).Start();
        }
    }
}