namespace Frontend.Handlers
{
    using Messages;
    using NServiceBus;
    using NServiceBus.Logging;

    public class PongHandler : IHandleMessages<Pong>
    {
        public void Handle(Pong message)
        {
            log.InfoFormat("PONG: {0}", message.Text);
        }

        readonly ILog log = LogManager.GetLogger<PongHandler>();
    }
}