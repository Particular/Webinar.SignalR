namespace Backend
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Messages;
    using NServiceBus;

    public class PingHandler : IHandleMessages<Ping>
    {
        public async Task Handle(Ping message, IMessageHandlerContext context)
        {
            Trace.TraceInformation("RECEIVED PING: {0} from {1}", message.Text, message.Username);

            await context.Reply(new Pong
            {
                Text = message.Text,
                Username = message.Username
            });

            Trace.TraceInformation("SENT PONG: {0} to {1}", message.Text, message.Username);
        }
    }
}