using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data;
using RestaurantManagement.Data.Entity.EmployeeEntity;
using RestaurantManagement.Services.EmpService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Services.EmpService
{
    public class EmployeeService: IEmployeeService
    {
        protected AppDbContext _context;
        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployeeList()
        {
            return await _context.Employees.Include(x => x.Department).Include(x => x.Designation).Include(x => x.Gender).AsNoTracking().ToListAsync();
        }
    }
}
