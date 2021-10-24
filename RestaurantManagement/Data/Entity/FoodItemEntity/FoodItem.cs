using RestaurantManagement.Data.Entity.MasterDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RestaurantManagement.Data.Entity.FoodItemEntity
{
    public class FoodItem:Base
    {
        public string foodImage { get; set; }
        public string itemName { get; set; }
        public string description { get; set; }
        public float? unitPrice { get; set; }
        public float? vatPercent { get; set; }
        //fk
          public int? FoodCategoryId { get; set; }
          public FoodCategory FoodCategory { get; set; }
          public int? UnitId { get; set; }
          public Unit Unit { get; set; }
    }
}
