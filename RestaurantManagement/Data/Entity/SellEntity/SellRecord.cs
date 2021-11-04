using RestaurantManagement.Data.Entity.FoodItemEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Data.Entity.SellEntity
{
    public class SellRecord:Base
    {
        public int? FoodItemId { get; set; }
        public FoodItem FoodItem { get; set; }

        public  string boucherNo { get; set; }  // must save with boucherNo from controller with auto increament
        public float? quantity { get; set; }
        public float? returnQuantity { get; set; }  //by default zero will save 
        public float? netQuantity { get; set; }  //netQuantity=quantity-returnQuantity
        public float? unitPrice { get; set; }
        public float? vatAmount { get; set; } //form item table
        public float? discount { get; set; }
        public float? subTotal { get; set; }   //calculated Column ,subtotal=netQuantiy*unitPrice+(netQuantiy*unitPrice)*vatPercent-discount
     public DateTime? SellDate { get; set; } //DateTime.Now
          public int? tableNo { get; set; }
        //sell by==Created By
        //status=1=onProcess,2=Delivered,3=completed
        //(status=1=onProcess,2=Delivered) eta diye sell Order list toiri hobe
        //(3=completed) diye Sell List toiri hobe
    }
}
