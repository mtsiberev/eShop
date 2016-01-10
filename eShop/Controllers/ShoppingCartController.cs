using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary.Facade;
using ClassLibrary.Repository;

namespace eShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private Facade m_facade = new Facade(new ProductRepository());
        
        public JsonResult GetAllProducts()
        {
            var productsListBo = m_facade.GetAllProducts();

            if (productsListBo == null)
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);

            var anonArray = new List<dynamic>();
            foreach (var productBo in productsListBo)
            {
                anonArray.Add(
                    new { id = productBo.Id, catalogId = productBo.CatalogId, name = productBo.Name, description = productBo.Description });
            }
            return Json(anonArray, JsonRequestBehavior.AllowGet);
        }
        
    }
}
