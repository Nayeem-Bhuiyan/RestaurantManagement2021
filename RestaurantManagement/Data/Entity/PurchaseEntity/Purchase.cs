using RestaurantManagement.Data.Entity.MasterDataEntity;
using RestaurantManagement.Data.Entity.SupplierEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Data.Entity.PurchaseEntity
{
    public class Purchase:Base
    {
          public string boucherNo { get; set; }  // must save with boucherNo from controller with auto increament
        public float? quantity { get; set; } 
        public float? returnQuantity { get; set; }  //by default zero will save 
        public float? netQuantity { get; set; }  //netQuantity=quantity-returnQuantity
        public float? unitPrice { get; set; }
        public float? vatAmount { get; set; } //form item table
        public float? discount { get; set; }
        public float? subTotal { get; set; }   //calculated Column ,subtotal=netQuantiy*unitPrice+(netQuantiy*unitPrice)*vatPercent-discount
     public DateTime? needDate { get; set; }  //CreatedAt==orderDate
     public DateTime? supplyDate { get; set; }
        //fk
          public int? ItemId { get; set; }
          public Item Item { get; set; } 

          public int? SupplierId { get; set; }
          public Supplier Supplier { get; set; }

          public int? CategoryId { get; set; }
          public Category Category { get; set; }

          public int? UnitId { get; set; }
          public Unit Unit { get; set; }
    }
}
