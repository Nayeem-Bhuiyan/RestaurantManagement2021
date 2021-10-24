using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data;
using RestaurantManagement.Data.Entity.SalaryEntity;
using RestaurantManagement.Services.SalaryService.Interface;

namespace RestaurantManagement.Services.SalaryService
{
    public class MonthlyDeductionService: IMonthlyDeductionService
    {
        protected AppDbContext _context;
        public MonthlyDeductionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MonthlyDeduction>> MonthlyDeductionList()
        {
            return await _context.MonthlyDeductions.Include(x => x.Employee).AsNoTracking().ToListAsync();
        }

    }
}
