using RestaurantManagement.Data.Entity.EmployeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Services.EmpService.Interface
{
   public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployeeList();
    }
}
