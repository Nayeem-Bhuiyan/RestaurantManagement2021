using RestaurantManagement.Data.Entity.MasterDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Data.Entity.EmployeeEntity
{
    public class Employee:Base
    {
        public string empID { get; set; }
        public string name { get; set; }
        //fk
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; } 
        public int? DesignationId { get; set; }
        public virtual Designation Designation { get; set; } 
        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }

        public int? empStatus { get; set; } //1=permanent,2=contractual
        public string pictureUrl { get; set; }
        public string cvUrl { get; set; }
        public string contactNo { get; set; }
        public string address { get; set; }
        public string fatherName { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public DateTime? joiningDate { get; set; }
        
    }
}
