using RestaurantManagement.Data.Entity.MasterDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.MasterDataArea.Models
{
    public class ItemViewModel
    {
        public int ItemId { get; set; }
        public string itemName { get; set; }
        public string itemDescription { get; set; }
        public string itemCode { get; set; }
        public float? vatPercent { get; set; }
        //fk
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public int? UnitId { get; set; }
        public Unit Unit { get; set; }

        public virtual IEnumerable<Category> categories { get; set; }
        public virtual IEnumerable<Unit> units { get; set; }
        public virtual IEnumerable<Item> items { get; set; }
        public virtual Item item { get; set; }
    }
}
