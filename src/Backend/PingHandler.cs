namespace Backend
{
    using System.Diagnostics;
    using Messages;
    using NServiceBus;

    public class PingHandler : IHandleMessages<Ping>
    {
        public PingHandler(IBus bus)
        {
            this.bus = bus;
        }

        public void Handle(Ping message)
        {
            Trace.TraceInformation("RECEIVED PING: {0}", message.Text);
            Trace.TraceInformation("SENDING PONG: {0}", message.Text);

            bus.Send(new Pong
            {
                Text = message.Text
            });
        }

        IBus bus;
    }
}