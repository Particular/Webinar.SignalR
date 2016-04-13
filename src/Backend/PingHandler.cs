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
            Trace.TraceInformation("RECEIVED PING: {0} from {1}", message.Text, message.Username);

            bus.Reply(new Pong
            {
                Text = message.Text,
                Username = message.Username
            });

            Trace.TraceInformation("SENT PONG: {0} to {1}", message.Text, message.Username);
        }

        IBus bus;
    }
}