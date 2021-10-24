using RestaurantManagement.Data.Entity.EmployeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Data.Entity.SalaryEntity
{
    public class MonthlyDeduction:Base
    {
       
        public int? providentFund { get; set; }
        public int? incomeTax { get; set; }
        public int? others { get; set; }
        //fk
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
