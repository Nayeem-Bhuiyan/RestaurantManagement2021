using RestaurantManagement.Data.Entity.PurchasePayEntity;
using RestaurantManagement.Data.Entity.SupplierEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.PurchasePayArea.Models
{
    public class PurchaseBillPaymentViewModel
    {
        public int PurchaseBillPaymentId { get; set; }

        public int? purchaseBoucherNo { get; set; }
        public float? totalBoucherBill { get; set; }
        public float? payAmount { get; set; } //ak e boucher er payAmount edit hole just ager payAmount er sathe plus hobe
        public string payTo { get; set; }
        public int? SupplierId { get; set; }  //supplierId null hole zeroba nijeder fixed official number porbe as non supplier hisebe
        public Supplier Supplier { get; set; }
        //public int? status { get; set; }  payamount zero hole status=0(No Payment),payamount<totalBoucherBill=1(partial Payment),payamount==totalBoucherBill=2(full paid),payamount>totalBoucherBill=3(advance pay)

        public virtual IEnumerable<Supplier> suppliers { get; set; }
        public virtual IEnumerable<PurchaseBillPayment> purchaseBillPayments { get; set; }
        public virtual PurchaseBillPayment purchaseBillPayment { get; set; }
    }
}
