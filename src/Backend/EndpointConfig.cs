namespace Backend
{
    using NServiceBus;
    using Shared;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Worker
    {
        public void Customize(EndpointConfiguration configuration)
        {
            configuration.UseTransport<RabbitMQTransport>()
                .ConnectionString(RabbitMqConnectionString.Value);
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.EnableInstallers();
        }
    }
}