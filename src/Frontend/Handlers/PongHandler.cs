namespace Frontend.Handlers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Hubs;
    using Messages;
    using Microsoft.AspNet.SignalR;
    using NServiceBus;

    public class PongHandler : IHandleMessages<Pong>
    {
        public Task Handle(Pong message, IMessageHandlerContext context)
        {
            Trace.TraceInformation("RECEIVED PONG: {0}", message.Text);

            IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<PingPongHub>();
            hubContext.Clients.All.pong(message.Text);

            return Task.FromResult(0);
        }
    }
}