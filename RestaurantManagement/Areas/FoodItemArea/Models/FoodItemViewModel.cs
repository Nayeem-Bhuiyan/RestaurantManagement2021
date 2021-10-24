using Microsoft.AspNetCore.Http;
using RestaurantManagement.Data.Entity.FoodItemEntity;
using RestaurantManagement.Data.Entity.MasterDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.FoodItemArea.Models
{
    public class FoodItemViewModel
    {
        public int FoodItemId { get; set; }

        public string foodImage { get; set; }
        public IFormFile IFormFoodImage { get; set; }
        public string itemName { get; set; }
        public string description { get; set; }
        public float? unitPrice { get; set; }
        public float? vatPercent { get; set; }
        //fk
        public int? FoodCategoryId { get; set; }
        public FoodCategory FoodCategory { get; set; }
        public int? UnitId { get; set; }
        public Unit Unit { get; set; }

        public virtual IEnumerable<FoodCategory> foodCategories { get; set; }
        public virtual IEnumerable<Unit> units { get; set; }
        public virtual IEnumerable<FoodItem> foodItems { get; set; }
        public virtual FoodItem foodItem { get; set; }
    }
}
