using RestaurantManagement.Data.Entity.EmployeeEntity;
using RestaurantManagement.Data.Entity.SalaryEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Areas.SalaryArea.Models
{
    public class SalaryPaymentViewModel
    {
        public int SalaryPaymentId { get; set; }
        public int? paidTotal { get; set; }  //total paid Amount
        public DateTime? processDate { get; set; }
        public int? totalPaybale { get; set; }  //total salary have to pay(salary of salary structure+overtime+specicial/bonous)
        public int? totalSalary { get; set; }  //total salary of salary structure

        //fk
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int? EarningSalaryId { get; set; }
        public EarningSalary EarningSalary { get; set; }


        public SalaryPayment salaryPayment { get; set; }
        public IEnumerable<SalaryPayment> salaryPayments { get; set; }
        public IEnumerable<SalaryPayRecord> salaryPayRecords { get; set; }
        public IEnumerable<Employee> employees { get; set; }
        public IEnumerable<EarningSalary> earningSalaries { get; set; }
    }
}
