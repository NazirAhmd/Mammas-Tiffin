using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MammasTiffin.Web.ViewModels.Admin
{
    public class AddItemViewModel : BaseViewModel
    {
        public AddItemViewModel()
        {
            ItemDetail = new ItemDetailVM();
        }
        public ItemDetailVM ItemDetail { get; set; }

        public string Message { get; set; }
    }
    public class ItemDetailVM
    {
        public ItemDetailVM()
        {
            VegNonVegSelectList = new List<SelectListItem>
            {
                new SelectListItem{Value="Y",Text="Veg"},
                new SelectListItem{Value="N",Text="Non-Veg"}
            };
        }
        public int Id { get; set; }

        [Display(Name = "Name:")]
        [Required]
        public string ItemName { get; set; }

        [Display(Name = "Veg/Non-Veg?:")]
        [Required]
        public string IsVeg { get; set; }

        public List<SelectListItem> VegNonVegSelectList { get; set; }

        [Display(Name = "Price:")]
        [Required]
        public decimal? Price { get; set; }

        [Display(Name = "Ingredients Used:")]
        [Required]
        public string Ingredients { get; set; }

        [Display(Name = "Please upload the image of the dish:")]
        [Required]
        public HttpPostedFileBase File { get; set; }
    }
}