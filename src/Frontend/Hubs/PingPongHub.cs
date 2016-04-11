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
            Trace.TraceInformation("[{0}] CLIENT CONNECTED", Context.ConnectionId);
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
            Trace.TraceInformation("SENDING PING: {0}", text);

            bus.Send(new Ping
            {
                Text = text
            });
        }

        IBus bus;
    }
}