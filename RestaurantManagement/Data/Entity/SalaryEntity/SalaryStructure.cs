using RestaurantManagement.Data.Entity.EmployeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Data.Entity.SalaryEntity
{
    public class SalaryStructure:Base
    {
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
    }
}
