namespace Backend
{
    using Messages;
    using NServiceBus;
    using NServiceBus.Logging;

    public class PingHandler : IHandleMessages<Ping>
    {
        public PingHandler(IBus bus)
        {
            this.bus = bus;
        }

        public void Handle(Ping message)
        {
            log.InfoFormat("PING: {0}", message.Text);

            bus.Send(new Pong
            {
                Text = message.Text
            });
        }

        readonly ILog log = LogManager.GetLogger<PingHandler>();
        IBus bus;
    }
}