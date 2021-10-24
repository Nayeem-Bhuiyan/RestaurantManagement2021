using RestaurantManagement.Data.Entity.KitchenEntity;
using RestaurantManagement.Data.Entity.MasterDataEntity;
using RestaurantManagement.Data.Entity.PurchaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.KitchenArea.Models
{
    public class KitchenSupplyViewModel
    {
        public int KitchenSupplyId { get; set; }

        //fk
        public int? ItemId { get; set; }
        public Item Item { get; set; }
        public string OrderCode { get; set; }  //auto from controller
        public float? quantity { get; set; }
        public float? returnQuantity { get; set; }  //by default zero will be saved 
        public float? netQuantity { get; set; }  //netQuantity=quantity-returnQuantity
        //supply date===createdAt

        

        public virtual IEnumerable<Item> items { get; set; }
        public virtual IEnumerable<KitchenSupply> kitchenSupplys { get; set; }
        public virtual IEnumerable<KitchenDetailsViewModel> kitchenDetailsViewModels { get; set; }
        public virtual IEnumerable<Purchase> purchases { get; set; }
        public virtual KitchenSupply kitchenSupply { get; set; }
    }
}
