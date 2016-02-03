using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace eShop.Models
{
    public class RegistrationAccount : BaseAccount
    {
        public string ConfirmPassword { get; set; }
    }
}