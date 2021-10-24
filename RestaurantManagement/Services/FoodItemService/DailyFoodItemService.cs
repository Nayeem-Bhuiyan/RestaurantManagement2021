using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data;
using RestaurantManagement.Data.Entity.FoodItemEntity;

namespace RestaurantManagement.Services.FoodItemService
{
    public class DailyFoodItemService
    {
        protected AppDbContext _context;
        public DailyFoodItemService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DailyFoodItem>> DailyFoodItemList()
        {
            return await _context.DailyFoodItems.Include(x => x.FoodCategory).Include(x => x.FoodItem).Include(x => x.Unit).AsNoTracking().ToListAsync();
        }

    }
}
