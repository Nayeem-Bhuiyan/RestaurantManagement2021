using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data;

namespace RestaurantManagement.Services.SupplierService
{
    public class SupplierDetailsService
    {
        protected AppDbContext _context;
        public SupplierDetailsService(AppDbContext context)
        {
            _context = context;
        }
    }
}
