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
    public class EarningSalaryService: IEarningSalaryService
    {
        protected AppDbContext _context;
        public EarningSalaryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EarningSalary>> EarningSalaryList()
        {
            return await _context.EarningSalaries.Include(x => x.SalaryStructure).Include(x => x.Employee).AsNoTracking().ToListAsync();
        }
    }
}
