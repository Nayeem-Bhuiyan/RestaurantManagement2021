using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagement.Areas.Auth.Models
{
    public class UserListViewModel
    {
        public IEnumerable<AspNetUsersViewModel> aspNetUsersViewModels { get; set; }
        public IEnumerable<ApplicationRoleViewModel> userRoles { get; set; }

    }
}
