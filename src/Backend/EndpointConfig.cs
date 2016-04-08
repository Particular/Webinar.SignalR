namespace Backend
{
    using NServiceBus;
    using NServiceBus.Logging;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Worker
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.UseTransport<RabbitMQTransport>()
                .ConnectionString("host=lab-linux;username=marcin;password=marcin");
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.EnableInstallers();

            LogManager.Use<DefaultFactory>().Level(LogLevel.Debug);
        }
    }
}