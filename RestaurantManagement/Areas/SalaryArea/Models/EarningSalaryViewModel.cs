using RestaurantManagement.Data.Entity.EmployeeEntity;
using RestaurantManagement.Data.Entity.SalaryEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.SalaryArea.Models
{
    public class EarningSalaryViewModel
    {
        public int EarningSalaryId { get; set; }

        public int? totalSalary { get; set; }
        public float? hourlyPayRate { get; set; }

        public int? absentTotal { get; set; }
        public int? overtimes { get; set; }
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


        public EarningSalary earningSalary { get; set; }
        public IEnumerable<EarningSalary> earningSalaries { get; set; }
        public IEnumerable<Employee> employees { get; set; }
        public IEnumerable<SalaryStructure> salaryStructures { get; set; }

    }
}
