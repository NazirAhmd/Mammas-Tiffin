using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MammasTiffin.BusinessComponent.BusinessModels
{
    public class CustomerBM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string MobileNum { get; set; }
        public string Password { get; set; }
    }
}
