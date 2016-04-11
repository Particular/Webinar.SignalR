namespace Backend
{
    using Microsoft.WindowsAzure.ServiceRuntime;
    using NServiceBus.Hosting.Azure;

    public class WorkerRole : RoleEntryPoint
    {
        public override bool OnStart()
        {
            nsb.Start();

            return base.OnStart();
        }

        public override void OnStop()
        {
            nsb.Stop();

            base.OnStop();
        }

        NServiceBusRoleEntrypoint nsb = new NServiceBusRoleEntrypoint();
    }
}