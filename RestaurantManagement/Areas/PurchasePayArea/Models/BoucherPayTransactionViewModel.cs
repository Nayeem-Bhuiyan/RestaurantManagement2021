using RestaurantManagement.Data.Entity.PurchasePayEntity;
using RestaurantManagement.Data.Entity.SupplierEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.PurchasePayArea.Models
{
    public class BoucherPayTransactionViewModel
    {
        public int BoucherPayTransactionId { get; set; }

        public int? purchaseBoucherNo { get; set; }
        public float? totalBoucherBill { get; set; }

        public float? payAmount { get; set; }
        public DateTime? payDate { get; set; } //DateTime.Now
        public int? SupplierId { get; set; }  //supplierId null hole ( nijeder akta fixed number porbe ja dara bujabe direct purchase hoise)
        public Supplier Supplier { get; set; }

        public virtual IEnumerable<Supplier> suppliers { get; set; }
        public virtual IEnumerable<BoucherPayTransaction> boucherPayTransactions { get; set; }
        public virtual BoucherPayTransaction boucherPayTransaction { get; set; }
    }
}
