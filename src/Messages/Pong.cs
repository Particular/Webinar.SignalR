namespace Messages
{
    using NServiceBus;

    public class Pong : IMessage
    {
        public string Text { get; set; }
        public string Username { get; set; }
    }
}