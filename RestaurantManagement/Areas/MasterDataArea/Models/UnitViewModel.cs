
using RestaurantManagement.Data.Entity.MasterDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.MasterDataArea.Models
{
    public class UnitViewModel
    {
        public int UnitId { get; set; }

        public string unitName { get; set; }
        public string description { get; set; }

        public virtual IEnumerable<Unit> units { get; set; }
        public virtual Unit unit { get; set; }
    }
}
