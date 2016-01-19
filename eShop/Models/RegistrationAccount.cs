using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eShop.Models
{
    public class RegistrationAccount : BaseAccount
    {
        /*
        [Remote("IsUserNameExist", "Account", HttpMethod = "POST",
            ErrorMessageResourceType = typeof(Resource),
            ErrorMessageResourceName = "UserExists"
            )]

        [System.ComponentModel.DataAnnotations.Compare("Password",
            ErrorMessageResourceType = typeof(Resource),
            ErrorMessageResourceName = "PasswordConfirmationError"
            )]
        */
    
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
    }
}