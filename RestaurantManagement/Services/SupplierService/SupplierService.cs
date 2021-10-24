using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data;

namespace RestaurantManagement.Services.SupplierService
{
    public class SupplierService
    {
        protected AppDbContext _context;
        public SupplierService(AppDbContext context)
        {
            _context = context;
        }
    }
}
