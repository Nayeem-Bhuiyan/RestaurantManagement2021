using RestaurantManagement.Data.Entity.EmployeeEntity;
using RestaurantManagement.Data.Entity.SalaryEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.SalaryArea.Models
{
    public class SalaryStructureViewModel
    {
        public int SalaryStructureId { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int? basic { get; set; }
        public int? homeRent { get; set; }
        public int? medical { get; set; }
        public int? transport { get; set; }
        public int? totalSalary { get; set; }
        public float? hourlyPayRate { get; set; }
        public DateTime? activeFrom { get; set; }
        public DateTime? activeTo { get; set; }

        public SalaryStructure salaryStructure { get; set; }
        public IEnumerable<SalaryStructure> salaryStructures { get; set; }
        public IEnumerable<Employee> employees { get; set; }

        //earning viewModel Property

        public int EarningSalaryId { get; set; }
        public int? absentTotal { get; set; }
        public int? overtimes { get; set; }
        public int? overTimePayAmount { get; set; }
        public int? special { get; set; }
        public int? totalPayableSalary { get; set; }
        public int? month { get; set; }
        public int? year { get; set; }
        public int? isApproved { get; set; }

        //fk
        public EarningSalary earningSalary { get; set; }
        public IEnumerable<EarningSalary> earningSalaries { get; set; }

        //extra
        public int? salaryMonth { get; set; }
    }
}
