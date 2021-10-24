using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Data.Entity.GeneralTransactionEntity
{
    public class AdminCashTransaction:Base  //owner cash out transaction
    {
     public DateTime? transactionDate { get; set; } //DateTime.Now
          public int? transactionType { get; set; }  //1=cashIn,2=cashOut
        public float? cashAmount { get; set; }
        public string payTo { get; set; } //userId
        public string payBy { get; set; } //userId auto
          public int? isApproved { get; set; }
    }
}
