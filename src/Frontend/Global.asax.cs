namespace Frontend
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Autofac;
    using Autofac.Integration.SignalR;
    using Messages;
    using Microsoft.AspNet.SignalR;
    using NServiceBus;
    using Shared;

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

            EndpointConfiguration configuration = new EndpointConfiguration("Frontend");
            configuration.UseContainer<AutofacBuilder>(c => c.ExistingLifetimeScope(container));
            configuration.UseTransport<RabbitMQTransport>()
                .ConnectionString(RabbitMqConnectionString.Value)
                .Routing().RouteToEndpoint(typeof(Ping), "Backend");
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.SendFailedMessagesTo("error");
            configuration.EnableInstallers();

            endpoint = Endpoint.Start(configuration).GetAwaiter().GetResult();

            ContainerBuilder updater = new ContainerBuilder();
            updater.RegisterInstance(endpoint).As<IMessageSession>().ExternallyOwned();
            updater.Update(container);

            GlobalHost.DependencyResolver = new AutofacDependencyResolver(container);
        }

        protected void Application_End()
        {
            endpoint.Stop().GetAwaiter().GetResult();
        }

        IEndpointInstance endpoint;
    }
}