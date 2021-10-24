using RestaurantManagement.Data.Entity.GeneralTransactionEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.GeneralTransactionArea.Models
{
    public class AdminCashTransactionViewModel
    {
        public int AdminCashTransactionId { get; set; }

        public DateTime? transactionDate { get; set; } //DateTime.Now
        public int? transactionType { get; set; }  //1=cashIn,2=cashOut
        public float? cashAmount { get; set; }
        public string payTo { get; set; } //userId
        public string payBy { get; set; } //userId auto
        public int? isApproved { get; set; }

        public virtual IEnumerable<AdminCashTransaction> adminCashTransactions { get; set; }
        public virtual AdminCashTransaction adminCashTransaction { get; set; }
    }
}
