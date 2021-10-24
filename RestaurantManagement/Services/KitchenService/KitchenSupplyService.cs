using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data;

namespace RestaurantManagement.Services.KitchenService
{
    public class KitchenSupplyService
    {
        protected AppDbContext _context;
        public KitchenSupplyService(AppDbContext context)
        {
            _context = context;
        }
    }
}
