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
    public class SalaryPaymentService: ISalaryPaymentService
    {
        protected AppDbContext _context;
        public SalaryPaymentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SalaryPayment>> SalaryPaymentList()
        {
            return await _context.SalaryPayments.Include(x => x.Employee).Include(x => x.EarningSalary).AsNoTracking().ToListAsync();
        }
    }
}
