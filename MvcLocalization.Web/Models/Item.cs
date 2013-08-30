using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MvcLocalization.LocalizationResources.Models;
using MvcLocalization.LocalizationResources.Models.Items;


namespace MvcLocalization.Web.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Display(Name = "ItemName", ResourceType = typeof(ItemResources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ValidationMessages))]
        public string Name { get; set; }

        [Display(Name = "ItemWeight", ResourceType = typeof(ItemResources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ValidationMessages))]
        public double Weight { get; set; }

        [Display(Name = "ItemPrice", ResourceType = typeof(ItemResources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ValidationMessages))]
        public decimal Price { get; set; }

        [Display(Name = "ItemProducedAt", ResourceType = typeof(ItemResources))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ValidationMessages))]
        public DateTime ProducedAt { get; set; }
    }
}