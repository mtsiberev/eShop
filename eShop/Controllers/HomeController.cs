using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary.BusinessObjects;
using ClassLibrary.Repository;
using WebMatrix.WebData;

namespace eShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            if (!WebSecurity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            
            var userRepo = new UserRepository();
            //userRepo.Add(new User(0, "second", "city"));
         //   userRepo.Add(new User(0, "third", "city"));

        //    var getUser = userRepo.GetById(1);

            userRepo.Update(new User(1, "firstUpdate", "cityUpdate"));

            var getAfterUpdating = userRepo.GetById(1);

            userRepo.Delete(1);

            var getAfterDeleting = userRepo.GetById(1);

            return View();
        }

    }
}
