using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary.BusinessObjects;
using ClassLibrary.Facade;
using ClassLibrary.Repository;
using WebMatrix.WebData;

namespace eShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
                Facade m_facade = new Facade(new ProductRepository());

            var newProduct = new Product(0, 0, "fdg", "fddfgdf");
            m_facade.AddProduct(newProduct);



            if (!WebSecurity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}
