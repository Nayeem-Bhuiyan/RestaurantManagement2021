using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagement.Data.Entity.ApplicationUsersEntity
{
    public class UserLogHistory:Base
    {
        [MaxLength(250)]
        public string userName { get; set; }
        [MaxLength(250)]
        public DateTime? logTime { get; set; }
        [MaxLength(250)]
        public string ipAddress { get; set; }
        [MaxLength(250)]
        public string browserName { get; set; }
        [MaxLength(250)]
        public string pcName { get; set; }
        [NotMapped]
        public string statusName { get; set; }
    }
}
