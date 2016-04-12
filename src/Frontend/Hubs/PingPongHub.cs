namespace Frontend.Hubs
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Messages;
    using Microsoft.AspNet.SignalR;
    using NServiceBus;

    public class PingPongHub : Hub
    {
        public PingPongHub(IBus bus)
        {
            this.bus = bus;
        }

        public override Task OnConnected()
        {
            var username = Context.QueryString["username"];

            if (!string.IsNullOrWhiteSpace(username))
            {
                Groups.Add(Context.ConnectionId, username);

                Trace.TraceInformation("[{0}] CLIENT CONNECTED: {1}", Context.ConnectionId, username);
            }
            else
            {
                Trace.TraceInformation("[{0}] CLIENT CONNECTED: ANONYMOUS", Context.ConnectionId);
            }

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Trace.TraceInformation("[{0}] CLIENT DISCONNECTED", Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            Trace.TraceInformation("[{0}] CLIENT RECONNECTED", Context.ConnectionId);
            return base.OnReconnected();
        }

        public void Ping(string text)
        {
            var username = Context.QueryString["username"];

            if (!string.IsNullOrWhiteSpace(username))
            {
                Trace.TraceInformation("SENDING PING: {0} to {1}", text, username);

                bus.Send(new Ping
                {
                    Text = text,
                    Username = username
                });
            }
        }

        IBus bus;
    }
}