using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTemplate02.Data.DataModels;
using WebTemplate02.Data.Interfaces;
using WebTemplate02.Data;
using WebTemplate02.Data.DataModels.Social;

namespace WebTemplate02.Data.Repositories
{
    public class AlphaUserRepository : IAlphaUserRepository
    {
        private ApplicationDbContext _Db;

        public AlphaUserRepository(ApplicationDbContext db)
        {
            _Db = db;

        }

        public AlphaUser AddUser(AlphaUser newUser)
        {
            throw new NotImplementedException();
        }

        public Task<AlphaUser> AddUserAsync(AlphaUser newUser)
        {
            throw new NotImplementedException();
        }

        public Task<AlphaUser> DeleteUserAsync(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<AlphaUser> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<List<AlphaUser>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public AlphaUser GetUser(AlphaUser User)
        {
            throw new NotImplementedException();
        }

        public AlphaUser GetUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public Task<AlphaUser> GetUserAsync(AlphaUser User)
        {
            throw new NotImplementedException();
        }

        public Task<AlphaUser> GetUserAsync(string UserId)
        {
            throw new NotImplementedException();
        }

        //public AlphaUser AddUser(AlphaUser newUser)
        //{
        //    _Db.AlphaUsers.Add(newUser);

        //    _Db.SaveChanges();

        //    return _Db.AlphaUsers.FirstOrDefault(u => u.UserId == newUser.UserId);
        //}

        //public async Task<AlphaUser> AddUserAsync(AlphaUser newUser)
        //{
        //    await _Db.AlphaUsers.AddAsync(newUser);

        //    var NewUser = await _Db.AlphaUsers.FindAsync(newUser);

        //    return NewUser;

        //}

        //public async Task<AlphaUser> DeleteUserAsync(string UserId)
        //{
        //    var foundUser = await _Db.AlphaUsers.FindAsync(UserId);

        //    return foundUser;
        //}

        //public List<AlphaUser> GetAllUsers()
        //{
        //    var foundUser = _Db.AlphaUsers.ToList();


        //    return foundUser;
        //}

        //public async Task<List<AlphaUser>> GetAllUsersAsync()
        //{
        //    var users = await _Db.AlphaUsers.ToListAsync();
        //    return users;
        //}

        //public AlphaUser GetUser(AlphaUser User)
        //{
        //    var foundUser = _Db.AlphaUsers.Where( u => u.UserId == User.UserId).ToList()[0];

        //    return foundUser;
        //}

        //public AlphaUser GetUser(string UserId)
        //{
        //    var foundUser = _Db.AlphaUsers.Where(u => u.UserId == UserId).ToList()[0];

        //    return foundUser;
        //}

        //public async Task<AlphaUser> GetUserAsync(AlphaUser User)
        //{
        //    var foundUser = await _Db.AlphaUsers.FindAsync(User.Id);

        //    return foundUser;
        //}

        //public async Task<AlphaUser> GetUserAsync(string UserId)
        //{
        //    var foundUser = await _Db.AlphaUsers.FindAsync(UserId);

        //    return foundUser;
        //}
    }
}
