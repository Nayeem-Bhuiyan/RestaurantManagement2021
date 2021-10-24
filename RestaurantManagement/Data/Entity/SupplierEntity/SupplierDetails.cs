using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Data.Entity.SupplierEntity
{
    public class SupplierDetails : Base
    {

        public string shopNo { get; set; }
        public string shopLocation { get; set; }
        public string licenceNo { get; set; }
        public string presentAddress { get; set; }
        public string permanentAddress { get; set; }

          public int? SupplierId { get; set; }
      public Supplier Supplier { get; set; }

    }
}
