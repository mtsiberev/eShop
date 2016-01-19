using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using eShop.Models;
using NLog;
using WebMatrix.WebData;

namespace eShop.Controllers
{
    public class AccountController : Controller
    {
        private Logger m_logger = LogManager.GetCurrentClassLogger();

        
        [HttpGet]
        public ActionResult RedirectToHome()
        {
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Account account)
        {
            bool success = false;
            try
            {
                success = WebSecurity.Login(account.UserName, account.Password, false);
            }
            catch (Exception ex)
            {
                m_logger.Error(ex);
            }

            if (success)
            {
                //return RedirectToAction("Index", "Home");
                return RedirectToAction("Index", "Shop");
            }

            const string loginErrorMsg = "Login error";
            ViewData["error"] = loginErrorMsg;
            m_logger.Error(loginErrorMsg);

            return View();
        }

        
        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ActionResult Register()
        {
            var role = Roles.Provider;
            if (!role.RoleExists("admin"))
            {
                role.CreateRole("admin");
            }

            if (!role.RoleExists("user"))
            {
                role.CreateRole("user");
            }

            return View();
        }


        [HttpPost]
        public ActionResult Register(RegistrationAccount account)
        {
            try
            {
                {
                    WebSecurity.CreateUserAndAccount(
                        account.UserName,
                        account.Password,
                        propertyValues: new
                        {
                            Address = account.Address
                        });
                }

                if (account.UserName == "admin")
                {
                    var role = System.Web.Security.Roles.Provider;
                    role.AddUsersToRoles(
                        new[] { account.UserName },
                        new[] { "admin" });
                }
                else
                {
                    var role = System.Web.Security.Roles.Provider;
                    role.AddUsersToRoles(
                        new[] { account.UserName },
                        new[] { "user" });
                }
            }
            catch (Exception ex)
            {
                m_logger.Error(ex);
                return RedirectToAction("Register", "Account");
            }

            return Login(new Account(account.UserName, account.Password));
        }

        public ActionResult Administration()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public JsonResult IsUserNameExist(string userName)
        {
            var result = IsUserCreated(userName);
            return Json(!result);
        }

        [HttpPost]
        public JsonResult IsUserNameNotExist(string userName)
        {
            var result = IsUserCreated(userName);
            return Json(result);
        }

        private bool IsUserCreated(string userName)
        {
            var role = Roles.Provider;
            bool result;

            try
            {
                var user = role.GetRolesForUser(userName);
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

    }
}
