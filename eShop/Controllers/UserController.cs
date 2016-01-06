using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary.BusinessObjects;
using ClassLibrary.Facade;
using ClassLibrary.Repository;
using NLog;

namespace eShop.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private Facade m_facade = new Facade(new UserRepository());

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public JsonResult GetUser(int id)
        {
            var userBo = m_facade.GetUserById(id);
            var user = new { id = userBo.Id, name = userBo.Name };
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllUsers()
        {
            var usersListBo = m_facade.GetAllUsers();
           
            var anonArray = new List<dynamic>();
            foreach (var user in usersListBo)
            {
                anonArray.Add( new {id = user.Id, name = user.Name });
            }

            return Json(anonArray, JsonRequestBehavior.AllowGet);
        }
        
    }
}
