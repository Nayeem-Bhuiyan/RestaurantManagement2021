using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data;

namespace RestaurantManagement.Services.Purchase
{
    public class PurchaseService
    {
        protected AppDbContext _context;
        public PurchaseService(AppDbContext context)
        {
            _context = context;
        }
    }
}
