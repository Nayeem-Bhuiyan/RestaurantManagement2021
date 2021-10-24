using RestaurantManagement.Data.Entity.SupplierEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.SupplierArea.Models
{
    public class SupplierViewModel
    {
        public int SupplierId { get; set; }


        public string supplierName { get; set; }
        public string contactNo { get; set; }

        public virtual IEnumerable<Supplier> suppliers { get; set; }
        public virtual Supplier supplier { get; set; }
    }
}
