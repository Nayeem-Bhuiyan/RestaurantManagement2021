using RestaurantManagement.Data.Entity.EmployeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Data.Entity.SalaryEntity
{
    public class SalaryPayment:Base
    {
        public int? paidTotal { get; set; }  //total paid Amount
        public DateTime? processDate { get; set; }
        public int? totalPaybale { get; set; }  //total salary have to pay

        //fk
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int? EarningSalaryId { get; set; }
        public EarningSalary EarningSalary { get; set; }

    }
}
