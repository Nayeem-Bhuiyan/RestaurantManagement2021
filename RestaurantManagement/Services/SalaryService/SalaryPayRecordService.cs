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
    public class SalaryPayRecordService: ISalaryPayRecordService
    {
        protected AppDbContext _context;
        public SalaryPayRecordService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SalaryPayRecord>> SalaryPayRecordList()
        {
            return await _context.SalaryPayRecords.Include(x => x.EarningSalary).Include(x => x.Employee).AsNoTracking().ToListAsync();
        }
    }
}
