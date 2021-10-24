using RestaurantManagement.Data.Entity.EmployeeEntity;
using RestaurantManagement.Data.Entity.SalaryEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.SalaryArea.Models
{
    public class MonthlyDeductionViewModel
    {
        public int? providentFund { get; set; }
        public int? incomeTax { get; set; }
        public int? others { get; set; }
        //fk
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }


        public MonthlyDeduction monthlyDeduction { get; set; }
        public IEnumerable<MonthlyDeduction> monthlyDeductions { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
