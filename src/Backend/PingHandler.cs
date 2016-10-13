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
            Trace.TraceInformation("RECEIVED PING: {0}", message.Text);

            await context.Reply(new Pong
            {
                Text = message.Text
            });

            Trace.TraceInformation("SENT PONG: {0}", message.Text);
        }
    }
}