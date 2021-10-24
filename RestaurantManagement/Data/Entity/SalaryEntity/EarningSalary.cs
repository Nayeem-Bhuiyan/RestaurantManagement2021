using RestaurantManagement.Data.Entity.EmployeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Data.Entity.SalaryEntity
{
    public class EarningSalary:Base
    {
        public int? absentTotal { get; set; }
        public int? overtimes { get; set;}
        public int? overTimePayAmount { get; set; }
        public int? special { get; set; }
        public int? SalaryStructureId { get; set; }
        public SalaryStructure SalaryStructure { get; set; }
        public int? totalPayableSalary { get; set; }
        public int? month { get; set; }
        public int? year { get; set; }
        public int? isApproved { get; set; }
        //fk
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
