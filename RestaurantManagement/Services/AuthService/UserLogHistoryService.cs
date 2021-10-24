using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data;
using RestaurantManagement.Data.Entity.ApplicationUsersEntity;
using RestaurantManagement.Services.AuthService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Services.AuthService
{
    public class UserLogHistoryService : IUserLogHistoryService
    {
        private readonly AppDbContext _context;

        public UserLogHistoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveUserLogHistory(UserLogHistory userLogHistory)
        {
            try
            {
                if (userLogHistory.Id != 0)
                {
                    _context.UserLogHistories.Update(userLogHistory);
                }
                else
                {
                    _context.UserLogHistories.Add(userLogHistory);
                }

                await _context.SaveChangesAsync();
                return userLogHistory.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<UserLogHistory>> GetAllUserLogHistory()
        {
            return await _context.UserLogHistories.Select(x => new UserLogHistory { userName = x.userName, logTime = x.logTime, ipAddress = x.ipAddress, statusName = x.status == 1 ? "Logged In" : x.status == 0 ? "Logged Out" : "Logged Off" }).ToListAsync();
        }

        public async Task<IEnumerable<UserLogHistory>> GetUserLogHistoryByUser(string userName)
        {
            return await _context.UserLogHistories.Where(x => x.createdBy == userName).ToListAsync();
        }

    }
}
