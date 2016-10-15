namespace Shared
{
    using System;

    public class RabbitMqConnectionString
    {
        public static string Value => "ADD_YOUR_RABBITMQ_CONNECTION_STRING_HERE";

        public static void EnsureConnectionStringIsProvided()
        {
            if (Value == "ADD_YOUR_RABBITMQ_CONNECTION_STRING_HERE")
            {
                throw new InvalidOperationException("Provide your connection string for RabbitMQ.");
            }
        }
    }
}