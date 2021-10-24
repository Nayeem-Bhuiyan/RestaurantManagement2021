using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Data.Entity.MasterDataEntity
{
    public class Unit:Base
    {
        public string unitName { get; set; }
        public string description { get; set; }
    }
}
