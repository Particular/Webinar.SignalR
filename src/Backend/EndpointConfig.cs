namespace Backend
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Worker
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.UseTransport<RabbitMQTransport>()
                .ConnectionString(RabbitMqConnectionString.Value);
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.EnableInstallers();
        }
    }
}