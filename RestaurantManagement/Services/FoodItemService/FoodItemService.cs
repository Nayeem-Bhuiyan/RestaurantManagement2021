using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data;

namespace RestaurantManagement.Services.FoodItemService
{
    public class FoodItemService
    {
        protected AppDbContext _context;
        public FoodItemService(AppDbContext context)
        {
            _context = context;
        }
    }
}
