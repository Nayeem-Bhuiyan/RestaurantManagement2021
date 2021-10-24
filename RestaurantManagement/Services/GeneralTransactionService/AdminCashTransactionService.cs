using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data;

namespace RestaurantManagement.Services.GeneralTransactionService
{
    public class AdminCashTransactionService
    {
        protected AppDbContext _context;
        public AdminCashTransactionService(AppDbContext context)
        {
            _context = context;
        }
    }
}
