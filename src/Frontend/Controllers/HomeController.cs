namespace Frontend.Controllers
{
    using System.Web.Mvc;
    using Messages;
    using NServiceBus;
    using NServiceBus.Logging;

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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        IBus bus;
        readonly ILog log = LogManager.GetLogger<HomeController>();
    }
}