using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Data.Entity.MasterDataEntity
{
    public class Item : Base
    {
        public string itemName { get; set; }
        public string itemDescription { get; set; }
        public string itemCode { get; set; }
        public float? vatPercent { get; set; }
        //fk
          public int? CategoryId { get; set; }
          public Category Category { get; set; }

         public int? UnitId { get; set; }
         public Unit Unit { get; set; }
    }
}
