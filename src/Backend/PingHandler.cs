namespace Backend
{
    using Messages;
    using NServiceBus;

    public class PingHandler : IHandleMessages<Ping>
    {
        public IBus Bus { get; set; }

        public void Handle(Ping message)
        {
            Bus.Reply(new Pong());
        }
    }
}