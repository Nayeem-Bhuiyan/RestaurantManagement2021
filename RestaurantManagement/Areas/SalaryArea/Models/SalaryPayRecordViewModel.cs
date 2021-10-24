using RestaurantManagement.Data.Entity.EmployeeEntity;
using RestaurantManagement.Data.Entity.SalaryEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.SalaryArea.Models
{
    public class SalaryPayRecordViewModel
    {
        //fk
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int? EarningSalaryId { get; set; }
        public EarningSalary EarningSalary { get; set; }
        public int? paidAmount { get; set; }
        public DateTime? paidDate { get; set; }

        public SalaryPayRecord salaryPayRecord { get; set; }
        public IEnumerable<SalaryPayRecord> salaryPayRecords { get; set; }
        public IEnumerable<Employee> employees { get; set; }
        public IEnumerable<EarningSalary> earningSalaries { get; set; }
    }
}
