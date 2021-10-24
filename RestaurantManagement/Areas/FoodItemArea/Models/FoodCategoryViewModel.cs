using RestaurantManagement.Data.Entity.FoodItemEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.FoodItemArea.Models
{
    public class FoodCategoryViewModel
    {
        public int FoodCategoryId { get; set; }
        public string foodCategoryName { get; set; }
        public int? parentCategoryId { get; set; }

        public virtual IEnumerable<FoodCategory> foodCategories { get; set; }
        public virtual FoodCategory foodCategory { get; set; }
    }
}
