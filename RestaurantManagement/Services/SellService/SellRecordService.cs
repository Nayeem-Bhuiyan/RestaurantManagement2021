using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data;

namespace RestaurantManagement.Services.SellService
{
    public class SellRecordService
    {
        protected AppDbContext _context;
        public SellRecordService(AppDbContext context)
        {
            _context = context;
        }
    }
}
