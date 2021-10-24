using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data;

namespace RestaurantManagement.Services.PurchasePayService
{
    public class BoucherPayTransactionService
    {
        protected AppDbContext _context;
        public BoucherPayTransactionService(AppDbContext context)
        {
            _context = context;
        }
    }
}
