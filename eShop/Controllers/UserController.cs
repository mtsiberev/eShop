using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ClassLibrary.BusinessObjects;
using ClassLibrary.Facade;
using ClassLibrary.IoC;
using ClassLibrary.Repository;
using NLog;

namespace eShop.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private Facade m_facade = ContainerWrapper.Container.GetInstance<Facade>();
        
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        public JsonResult GetUserId()
        {
            var userId = Convert.ToInt32(Membership.GetUser().ProviderUserKey.ToString());
            return Json(userId, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetUser(int id)
        {
            var userBo = m_facade.GetUserById(id);
            if (userBo == null)
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);

            var user = new { id = userBo.Id, name = userBo.Name, address = userBo.Address };
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllUsers()
        {
            var usersListBo = m_facade.GetAllUsers();

            if (usersListBo == null)
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);

            var anonArray = new List<dynamic>();
            foreach (var user in usersListBo)
            {
                anonArray.Add(new { id = user.Id, name = user.Name });
            }

            return Json(anonArray, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateUser(int id, string name, string address)
        {
            var updatedUser = new User(id, name, address);
            m_facade.UpdateUser(updatedUser);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteUser(int id)
        {
            m_facade.DeleteUser(id);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}
