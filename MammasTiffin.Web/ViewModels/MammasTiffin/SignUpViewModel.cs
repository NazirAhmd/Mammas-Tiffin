using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MammasTiffin.Web.ViewModels.MammasTiffin
{
    public class SignUpViewModel:BaseViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}