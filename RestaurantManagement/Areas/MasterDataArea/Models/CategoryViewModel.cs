using RestaurantManagement.Data.Entity.MasterDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.MasterDataArea.Models
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }

        public string categoryName { get; set; }
        public int? parentCategoryId { get; set; }

        public virtual IEnumerable<Category> categories { get; set; }
        public virtual Category category { get; set; }
    }
}
