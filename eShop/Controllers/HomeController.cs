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
            /*
            var facadeProduct = new Facade(new ProductRepository());
            var facadeCatalog = new Facade(new CatalogRepository());

            for (int i = 0; i < 10; i++)
            {
                var name = "Name" + i;
                var desc = "Desc" + i;
                var catalogName = "Catalog" + i;

                var newProduct = new Product(0, 0, name, desc);
                facadeProduct.AddProduct(newProduct);

                var newCatalog = new Catalog(0, catalogName);
                facadeCatalog.AddCatalog(newCatalog);
            }
            */

            if (!WebSecurity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}
