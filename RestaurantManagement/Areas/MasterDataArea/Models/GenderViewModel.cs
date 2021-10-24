using RestaurantManagement.Data.Entity.MasterDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.MasterDataArea.Models
{
    public class GenderViewModel
    {
        public int GenderId { get; set; }
        public string name { get; set; }
        public virtual IEnumerable<Gender>genders{ get; set; }
        public virtual Gender gender{ get; set; }
    }
}
