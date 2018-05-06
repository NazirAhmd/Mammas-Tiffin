using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MammasTiffin.BusinessComponent.BusinessModels
{
    public class ItemBM
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string IsVeg { get; set; }
        public decimal Price { get; set; }
        public string Ingredients { get; set; }
    }
}
