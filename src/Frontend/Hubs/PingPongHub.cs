namespace Frontend.Hubs
{
    using System.Diagnostics;
    using Messages;
    using Microsoft.AspNet.SignalR;
    using NServiceBus;

    public class PingPongHub : Hub
    {
        public PingPongHub(IBus bus)
        {
            this.bus = bus;
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