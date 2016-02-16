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
        private const int c_maxProductQty = 50;

        private Facade m_facade = ContainerWrapper.Container.GetInstance<Facade>();

        public JsonResult AddToCart(int productId, int qty = 0)
        {
            if ((qty > c_maxProductQty) || (qty <= 0))
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            };

            var userId = Convert.ToInt32(Membership.GetUser().ProviderUserKey.ToString());
            var order = m_facade.GetOrderByUserId(userId);
            var orderItem = m_facade.GetOrderItem(order.Id, productId);

            if (orderItem == null)
            {
                var product = m_facade.GetProductById(productId);
                m_facade.AddOrderItem(new OrderItem(order.Id, productId, qty, product.Name));
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }

            var newQty = orderItem.Qty + qty;
            if (newQty > c_maxProductQty) newQty = c_maxProductQty;

            orderItem.Qty = newQty;
            var orderItemUpdated = orderItem;
            m_facade.UpdateOrderItem(orderItemUpdated);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteFromCart(int productId)
        {
            var userId = Convert.ToInt32(Membership.GetUser().ProviderUserKey.ToString());
            var order = m_facade.GetOrderByUserId(userId);
            var orderItem = m_facade.GetOrderItem(order.Id, productId);

            if (orderItem == null)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }

            var newQty = orderItem.Qty - 1;
            if (newQty == 0)
            {
                m_facade.DeleteOrderItem(orderItem);
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }

            orderItem.Qty = newQty;
            var orderItemUpdated = orderItem;
            m_facade.UpdateOrderItem(orderItemUpdated);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
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

        public JsonResult ApproveOrder(int userId)
        {
            var order = m_facade.GetOrderByUserId(userId);

            if (order == null)
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            var orderId = m_facade.GetOrderByUserId(userId).Id;
            m_facade.DeleteOrder(orderId);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}
