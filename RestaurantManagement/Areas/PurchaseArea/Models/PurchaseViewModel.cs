using RestaurantManagement.Data.Entity.MasterDataEntity;
using RestaurantManagement.Data.Entity.PurchaseEntity;
using RestaurantManagement.Data.Entity.SupplierEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.PurchaseArea.Models
{
    public class PurchaseViewModel
    {
        public int PurchaseId { get; set; }

        public int? boucherNo { get; set; }  // must save with boucherNo from controller with auto increament
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


        public string itemDescription { get; set; }
        public string itemCode { get; set; }
        public string itemName { get; set; }
        public string unitName { get; set; }


        public virtual IEnumerable<Item> items { get; set; }
        public virtual IEnumerable<Unit> units { get; set; }
        public virtual IEnumerable<Category> categories { get; set; }
        public virtual IEnumerable<Supplier> suppliers { get; set; }
        public virtual IEnumerable<Purchase> purchases { get; set; }
        public virtual Purchase purchase { get; set; }
        public  List<PurchaseViewModel> modelList { get; set; }
    }
}
