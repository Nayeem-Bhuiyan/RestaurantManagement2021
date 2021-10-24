using RestaurantManagement.Data.Entity.MasterDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.MasterDataArea.Models
{
    public class DepartmentViewModel
    {
        public int DepartmentId { get; set; }
        public string name { get; set; }

        public virtual Department department { get; set; }
        public virtual IEnumerable<Department> departments { get; set; }
    }
}
