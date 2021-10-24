using RestaurantManagement.Data.Entity.EmployeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Data.Entity.SalaryEntity
{
    public class SalaryPayRecord:Base
    {
        //fk
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int? EarningSalaryId { get; set; }
        public EarningSalary EarningSalary { get; set; }
        public int? paidAmount { get; set; }
        public DateTime? paidDate { get; set; }
    }
}
