using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MammasTiffin.Web.ViewModels.MammasTiffin
{
    public class LoginViewModel : BaseViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}