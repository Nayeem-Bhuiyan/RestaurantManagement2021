using RestaurantManagement.Data.Entity.FoodItemEntity;
using RestaurantManagement.Data.Entity.MasterDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.FoodItemArea.Models
{
    public class DailyFoodItemViewModel
    {
        public int DailyFoodItemId { get; set; }

        //fk
        public int? FoodItemId { get; set; }
        public FoodItem FoodItem { get; set; }
        public int? FoodCategoryId { get; set; }
        public FoodCategory FoodCategory { get; set; }
        public int? UnitId { get; set; }
        public Unit Unit { get; set; }

        public virtual IEnumerable<FoodItem> foodItems { get; set; }
        public virtual IEnumerable<FoodCategory> foodCategories { get; set; }
        public virtual IEnumerable<Unit> units { get; set; }
        public virtual IEnumerable<DailyFoodItem> dailyFoodItems { get; set; }
        public virtual DailyFoodItem dailyFoodItem { get; set; }
    }
}
