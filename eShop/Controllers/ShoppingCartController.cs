using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ClassLibrary.BusinessObjects;
using ClassLibrary.Facade;
using ClassLibrary.IoC;
using ClassLibrary.Repository;
using WebMatrix.WebData;

namespace eShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private Facade m_facade = ContainerWrapper.Container.GetInstance<Facade>();

        public void AddToCart(int productId)
        {
            var userId = Convert.ToInt32(Membership.GetUser().ProviderUserKey.ToString());
            var order = m_facade.GetOrderByUserId(userId);
            var orderItem = m_facade.GetOrderItem(order.Id, productId);

            if (orderItem == null)
            {
                var product = m_facade.GetProductById(productId);
                m_facade.AddOrderItem(new OrderItem(order.Id, productId, 1, product.Name));
                return;
            }

            var newQty = orderItem.Qty + 1;
            orderItem.Qty = newQty;
            var orderItemUpdated = orderItem;
            m_facade.UpdateOrderItem(orderItemUpdated);
        }

        public void DeleteFromCart(int productId)
        {
            var userId = Convert.ToInt32(Membership.GetUser().ProviderUserKey.ToString());
            var order = m_facade.GetOrderByUserId(userId);
            var orderItem = m_facade.GetOrderItem(order.Id, productId);

            if (orderItem == null)
            {
                return;
            }

            var newQty = orderItem.Qty - 1;
            if (newQty == 0)
            {
                m_facade.DeleteOrderItem(orderItem);
                return;
            }

            orderItem.Qty = newQty;
            var orderItemUpdated = orderItem;
            m_facade.UpdateOrderItem(orderItemUpdated);
        }

        public JsonResult GetContentOfShoppingCart(int userId)
        {
            var orderForCurrentUser = m_facade.GetOrderByUserId(userId);
            if (orderForCurrentUser == null)
            {
                m_facade.AddOrder(new Order(0, userId, null));
                orderForCurrentUser = m_facade.GetOrderByUserId(userId);
            }

            if (orderForCurrentUser == null)
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);

            return Json(orderForCurrentUser, JsonRequestBehavior.AllowGet);
        }

        public void ApproveOrder(int userId)
        {
            var order = m_facade.GetOrderByUserId(userId);

            if (order == null) return;
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
