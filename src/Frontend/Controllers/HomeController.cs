namespace Frontend.Controllers
{
    using System.Web.Mvc;
    using Messages;
    using NServiceBus;

    public class HomeController : Controller
    {
        public HomeController(IBus bus)
        {
            this.bus = bus;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ping(string text)
        {
            bus.Send(new Ping
            {
                Text = text
            });

            return RedirectToAction("Index");
        }

        IBus bus;
    }
}