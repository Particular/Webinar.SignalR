namespace Frontend
{
    using System;
    using Microsoft.AspNet.SignalR;
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalHost.Configuration.ConnectionTimeout = TimeSpan.FromSeconds(6);
            GlobalHost.Configuration.DisconnectTimeout = TimeSpan.FromSeconds(6);

            app.MapSignalR();
        }
    }
}