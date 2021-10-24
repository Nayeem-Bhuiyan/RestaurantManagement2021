using RestaurantManagement.Data.Entity.SalaryEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Services.SalaryService.Interface
{
   public interface IEarningSalaryService
    {
        Task<IEnumerable<EarningSalary>> EarningSalaryList();
    }
}
