﻿using RestaurantManagement.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Data.Entity.ApplicationUsersEntity
{
    public class UserType : Base
    {

        [Column(TypeName = "nvarchar(250)")]
        public string userTypeName { get; set; }

        public int? shortOrder { get; set; }
    }
}
