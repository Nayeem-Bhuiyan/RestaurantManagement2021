using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Data.Entity.FoodItemEntity
{
    public class FoodCategory : Base
    {
        public string foodCategoryName { get; set; }
          public int? parentCategoryId { get; set; }
    }
}
