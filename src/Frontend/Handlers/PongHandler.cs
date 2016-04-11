namespace Frontend.Handlers
{
    using System.Diagnostics;
    using Hubs;
    using Messages;
    using Microsoft.AspNet.SignalR;
    using NServiceBus;

    public class PongHandler : IHandleMessages<Pong>
    {
        public void Handle(Pong message)
        {
            Trace.TraceInformation("RECEIVED PONG: {0}", message.Text);

            IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<PingPongHub>();
            hubContext.Clients.All.pong(message.Text);
        }
    }
}