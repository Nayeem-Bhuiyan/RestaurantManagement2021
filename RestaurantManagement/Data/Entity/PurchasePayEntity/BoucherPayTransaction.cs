using RestaurantManagement.Data.Entity.SupplierEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Data.Entity.PurchasePayEntity
{
    public class BoucherPayTransaction: Base  // ei table er data PurchaseBillPayment er sathe auto porbe 
    {
          public int? purchaseBoucherNo { get; set; }
        public float? totalBoucherBill { get; set; }

        public float? payAmount { get; set; }
        public DateTime? payDate { get; set; } //DateTime.Now
          public int? SupplierId { get; set; }  //supplierId null hole ( nijeder akta fixed number porbe ja dara bujabe direct purchase hoise)
          public Supplier Supplier { get; set; }
    }

    //BoucherPayTransaction table kora hoyeche ei karone je ake boucher er maddome kobe kobe kotobar taka pay kora hoyeche ta janar
}
