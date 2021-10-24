using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data;
using RestaurantManagement.Data.Entity.FoodItemEntity;

namespace RestaurantManagement.Services.FoodItemService
{
    public class FoodCategoryService
    {
        protected AppDbContext _context;
        public FoodCategoryService(AppDbContext context)
        {
            _context = context;
        }


    }
}
