using RestaurantManagement.Data.Entity.SupplierEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.SupplierArea.Models
{
    public class SupplierDetailsViewModel
    {
        public int SupplierDetailsId { get; set; }

        public string shopNo { get; set; }
        public string shopLocation { get; set; }
        public string licenceNo { get; set; }
        public string presentAddress { get; set; }
        public string permanentAddress { get; set; }
        public int? SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public virtual IEnumerable<Supplier> suppliers { get; set; }
        public virtual IEnumerable<SupplierDetails> supplierListDetails { get; set; }
        public virtual SupplierDetails supplierDetails { get; set; }
    }
}
