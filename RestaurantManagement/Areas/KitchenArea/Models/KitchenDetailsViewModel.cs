using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.KitchenArea.Models
{
    public class KitchenDetailsViewModel
    {
        public int? ItemId { get; set; }
        public string itemName { get; set; }
        public string itemCode { get; set; }
        public string itemDescription { get; set; }
        public float? purchaseTotalAmount { get; set; }
        public float? kitchenTotalSupplyAmount { get; set; }
        public float? stockAmount { get; set; }
        public string categoryName { get; set; }
        public string unitName { get; set; }
        public string unitDescription { get; set; }
    }
}
