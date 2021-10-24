using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Data.Entity.MasterDataEntity
{
    public class Category:Base
    {
        public string categoryName { get; set; }
          public int? parentCategoryId { get; set; }
    }
}
