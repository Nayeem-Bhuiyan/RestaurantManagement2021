using RestaurantManagement.Data.Entity.MasterDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.MasterDataArea.Models
{
    public class DesignationViewModel
    {
        public int DesignationId { get; set; }
        public string name { get; set; }
        public virtual Designation designation { get; set; }
        public virtual IEnumerable<Designation> designations { get; set; }
    }
}
