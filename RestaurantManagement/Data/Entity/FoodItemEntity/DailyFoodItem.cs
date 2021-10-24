using RestaurantManagement.Data.Entity.MasterDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RestaurantManagement.Data.Entity.FoodItemEntity
{
    public class DailyFoodItem:Base
    {
        //fk
            public int? FoodItemId { get; set; }
        public FoodItem FoodItem { get; set; }
            public int? FoodCategoryId { get; set; }
    public FoodCategory FoodCategory { get; set; }
            public int? UnitId { get; set; }
            public Unit Unit { get; set; }
    }
}
