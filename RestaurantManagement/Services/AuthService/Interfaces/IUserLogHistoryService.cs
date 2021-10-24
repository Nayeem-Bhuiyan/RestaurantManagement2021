using RestaurantManagement.Data.Entity.ApplicationUsersEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Services.AuthService.Interfaces
{
   public interface IUserLogHistoryService
    {
        Task<int> SaveUserLogHistory(UserLogHistory userLogHistory);

        Task<IEnumerable<UserLogHistory>> GetAllUserLogHistory();

        Task<IEnumerable<UserLogHistory>> GetUserLogHistoryByUser(string userName);
    }
}
