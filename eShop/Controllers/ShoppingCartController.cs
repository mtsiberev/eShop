using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary.BusinessObjects;
using ClassLibrary.Facade;
using ClassLibrary.Repository;

namespace eShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private Facade m_facade = new Facade(
            new UserRepository(), 
            new ProductRepository(), 
            new CatalogRepository(), 
            new OrderRepository(), 
            new OrderItemRepository());
        
        public JsonResult GetContentOfShoppingCart(int userId)
        {
            var orderForCurrentUser = m_facade.GetOrderByUserId(userId);
            if (orderForCurrentUser == null)
                m_facade.AddOrder(new Order(0, userId, null));
           orderForCurrentUser = m_facade.GetOrderByUserId(userId);
            
           if (orderForCurrentUser == null)
               return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            
           return Json(orderForCurrentUser, JsonRequestBehavior.AllowGet);
        }

        public void ApproveOrder(int userId)
        {
            var orderId = m_facade.GetOrderByUserId(userId).Id;
            m_facade.DeleteOrder(orderId);
        }
        
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
