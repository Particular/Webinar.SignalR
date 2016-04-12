namespace Backend
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Worker
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.UseTransport<RabbitMQTransport>()
                .ConnectionString("ADD_YOUR_RABBITMQ_CONNECTION_STRING_HERE");
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.EnableInstallers();
        }
    }
}