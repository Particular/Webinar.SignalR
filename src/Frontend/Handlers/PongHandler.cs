namespace Frontend.Handlers
{
    using System.Diagnostics;
    using Messages;
    using NServiceBus;

    public class PongHandler : IHandleMessages<Pong>
    {
        public void Handle(Pong message)
        {
            Trace.TraceInformation("PONG: {0}", message.Text);
        }
    }
}