using RestaurantManagement.Data.Entity.MasterDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Data.Entity.KitchenEntity
{
    public class KitchenSupply:Base
    {
        //fk
          public int? ItemId { get; set; }
          public Item Item { get; set; }
          public string OrderCode { get; set; }  //auto from controller
        public float? quantity { get; set; }
        public float? returnQuantity { get; set; }  //by default zero will be saved 
        public float? netQuantity { get; set; }  //netQuantity=quantity-returnQuantity

        //supply date===createdAt
    }
}
