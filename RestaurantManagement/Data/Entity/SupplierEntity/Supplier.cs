using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Data.Entity.SupplierEntity
{
    public class Supplier : Base
    {
        public string supplierName { get; set; }
        public string contactNo { get; set; }
    }
}
