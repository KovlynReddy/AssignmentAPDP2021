using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTemplate02.Data.DataModels;
using WebTemplate02.Data.DataModels.Social;

namespace WebTemplate02.Data.Interfaces
{
    public interface IAlphaUserRepository
    {
        Task<AlphaUser> AddUserAsync(AlphaUser newUser);
        AlphaUser AddUser(AlphaUser newUser);
        Task<AlphaUser> GetUserAsync(AlphaUser User);
        Task<AlphaUser> GetUserAsync(string UserId);    
        AlphaUser GetUser(AlphaUser User);
        AlphaUser GetUser(string UserId);
        Task<AlphaUser> DeleteUserAsync(string UserId);
        Task<List<AlphaUser>> GetAllUsersAsync();
        List<AlphaUser> GetAllUsers();
    }
}
