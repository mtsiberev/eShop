using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace eShop.Models
{
    public class Account : BaseAccount
    {

        public Account()
        {
        }

        public Account(string username, string password)
        {
            UserName = username;
            Password = password;
        }

        /*
        [Remote("IsUserNameNotExist", "Account", HttpMethod = "POST",
            ErrorMessageResourceType = typeof(Resource),
            ErrorMessageResourceName = "UserNotExists"
            )]
        */
   
    }
}