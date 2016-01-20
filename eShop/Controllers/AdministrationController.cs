using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eShop.Controllers
{
    public class AdministrationController : Controller
    {
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
