using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MammasTiffin.BusinessComponent.BusinessModels
{
    public class OrderDetailBM
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string IsActive { get; set; }
        public string IsDelivered { get; set; }
    }
}
