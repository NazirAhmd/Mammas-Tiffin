using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MammasTiffin.Web.ViewModels.MammasTiffin
{
    public class MenuViewModel : BaseViewModel
    {
        public MenuViewModel()
        {
            MenuDetailsList = new List<MenuDetail>();
        }
        public string MenuType { get; set; }
        public List<MenuDetail> MenuDetailsList { get; set; }
    }
    public class MenuDetail
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public string IsVeg { get; set; }
        public string Ingredients { get; set; }
        public byte[] ImageData { get; set; }
    }
}