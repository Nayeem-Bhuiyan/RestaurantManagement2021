using RestaurantManagement.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Data.Entity.ApplicationUsersEntity
{
    public class DbChangeHistory : Base
    {
        [MaxLength(300)]
        public string entityName { get; set; }
        [MaxLength(100)]
        public string entityState { get; set; }
        [MaxLength(200)]
        public string fieldName { get; set; }
        public string fieldValue { get; set; }
        public long? sessionId { get; set; }
    }
}
