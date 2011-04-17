using System;
using System.Web.Mvc;

using Messages.Commands;

using Web.Core;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new CreateEvent
            {
                EventId = Guid.NewGuid()
            });
        }
    
        [HttpPost]
        public ActionResult Index(CreateEvent e)
        {
            AzureEsb.SendCommand(e);
            return RedirectToAction("index");
        }
    }
}
