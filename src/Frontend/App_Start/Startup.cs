namespace Frontend
{
    using System;
    using Config;
    using Microsoft.AspNet.SignalR;
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalHost.DependencyResolver.UseRedis(RedisConnectionData.Server, RedisConnectionData.Port, RedisConnectionData.Password, "MessagingPingPong");

            GlobalHost.Configuration.ConnectionTimeout = TimeSpan.FromSeconds(6);
            GlobalHost.Configuration.DisconnectTimeout = TimeSpan.FromSeconds(6);

            app.MapSignalR();
        }
    }
}