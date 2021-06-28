using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTemplate02.Data.DataModels.InternalModels;
using WebTemplate02.Data.DataModels.ProfileModels;
using WebTemplate02.Data.Interfaces;

namespace WebTemplate02.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _Db;

        public UserRepository(ApplicationDbContext db)
        {
            this._Db = db;
        }

        #region Add

        public Contractor AddContractor(Contractor newAccount)
        {
            _Db.Contractors.Add(newAccount);

            _Db.SaveChanges();

            return _Db.Contractors.FirstOrDefault(u => u.ContractorId == newAccount.ContractorId);

        }
        public Transaction AddTransaction(Transaction newAccount)
        {
            _Db.Transactions.Add(newAccount);

            _Db.SaveChanges();

            return _Db.Transactions.FirstOrDefault(u => u.TransactionId == newAccount.TransactionId);
        }
        public UserProfile AddUserProfile(UserProfile newAccount)
        {
            _Db.UserProfiles.Add(newAccount);

            _Db.SaveChanges();

            return _Db.UserProfiles.FirstOrDefault(u => u.UserId == newAccount.UserId);
        }
        public UserAccount AddUserAccount(UserAccount newAccount)
        {
            _Db.UserAccounts.Add(newAccount);

            _Db.SaveChanges();

            return _Db.UserAccounts.FirstOrDefault(u => u.AccountId == newAccount.AccountId);
        }


        public Task<Contractor> AddContractorAsync(Contractor newAccount)
        {
            throw new NotImplementedException();
        }
        public Task<Transaction> AddTransactionAsync(Transaction newAccount)
        {
            throw new NotImplementedException();
        }
        public Task<UserAccount> AddUserAccountAsync(UserAccount newAccount)
        {
            throw new NotImplementedException();
        }
        public Task<UserProfile> AddUserProfileAsync(UserProfile newAccount)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Delete

        public Contractor DeleteContractor(Contractor Account)
        {
            throw new NotImplementedException();
        }
        public Transaction DeleteTransaction(Transaction Account)
        {
            throw new NotImplementedException();
        }
        public UserProfile DeleteUserProfile(UserProfile Account)
        {
            throw new NotImplementedException();
        }
        public UserAccount DeleteUserAccount(UserAccount Account)
        {
            throw new NotImplementedException();
        }


        public Task<UserAccount> DeleteUserAccountAsync(UserAccount Account)
        {
            throw new NotImplementedException();
        }
        public Task<Transaction> DeleteTransactionAsync(Transaction Account)
        {
            throw new NotImplementedException();
        }
        public Task<Contractor> DeleteContractorAsync(Contractor Account)
        {
            throw new NotImplementedException();
        }
        public Task<UserProfile> DeleteUserProfileAsync(UserProfile Account)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Get

        public UserAccount GetUserAccount(UserAccount Account)
        {
            var foundUser = _Db.UserAccounts.Where(u => u.AccountId == Account.AccountId).ToList()[0];

            return foundUser;
        }
        public Transaction GetTransaction(Transaction Account)
        {
            var foundUser = _Db.Transactions.Where(u => u.TransactionId == Account.TransactionId).ToList()[0];

            return foundUser;
        }
        public Contractor GetContractor(Contractor Account)
        {
            var foundUser = _Db.Contractors.Where(u => u.ContractorId == Account.ContractorId).ToList()[0];

            return foundUser;
        }
        public UserProfile GetUserProfile(UserProfile Account)
        {
            var foundUser = _Db.UserProfiles.Where(u => u.UserEmail == Account.UserId).ToList()[0];

            return foundUser;
        }

        public UserProfile GetUserProfileById(string AccountId)
        {
            var foundUser = _Db.UserProfiles.Where(u => u.UserEmail == AccountId).ToList()[0];

            return foundUser;
        }
        public Transaction GetTransactionById(string AccountId)
        {
            var foundUser = _Db.Transactions.Where(u => u.TransactionId == AccountId).ToList()[0];

            return foundUser;
        }
        public UserAccount GetUserAccountById(string AccountId)
        {
            var foundUser = _Db.UserAccounts.Where(u => u.UserId == AccountId).ToList().FirstOrDefault();

            return foundUser;
        }
        public Contractor GetContractorById(string AccountId)
        {
            var foundUser = _Db.Contractors.Where(u => u.ContractorId == AccountId).ToList()[0];

            return foundUser;
        }


        public List<Contractor> GetAllContractors()
        {
            var foundUser = _Db.Contractors.ToList();

            return foundUser;
        }
        public List<UserAccount> GetUserAccounts()
        {
            var foundUser = _Db.UserAccounts.ToList();

            return foundUser;
        }
        public List<UserProfile> GetUserProfile()
        {
            var foundUser = _Db.UserProfiles.ToList();

            return foundUser;
        }
        public List<Transaction> GetAllTransactions()
        {
            var foundUser = _Db.Transactions.ToList();

            return foundUser;
        }




        public Task<UserAccount> GetUserAccountAsync(UserAccount Account)
        {
            throw new NotImplementedException();
        }
        public Task<UserProfile> GetUserProfileAsync(UserProfile Account)
        {
            throw new NotImplementedException();
        }
        public Task<Contractor> GetContractorAsync(Contractor Account)
        {
            throw new NotImplementedException();
        }
        public Task<Transaction> GetTransactionAsync(Transaction Account)
        {
            throw new NotImplementedException();
        }

        public Task<Contractor> GetContractorIdAsync(string AccountId)
        {
            throw new NotImplementedException();
        }
        public Task<Transaction> GetTransactionIdAsync(string AccountId)
        {
            throw new NotImplementedException();
        }
        public Task<UserProfile> GetUserProfileByIdAsync(string AccountId)
        {
            throw new NotImplementedException();
        }
        public Task<UserAccount> GetUserAccountByIdAsync(string AccountId)
        {
            throw new NotImplementedException();
        }
        
        public Task<List<UserAccount>> GetUserAccountsAsync()
        {
            throw new NotImplementedException();
        }
        public Task<List<Transaction>> GetAllTransactionAsync()
        {
            throw new NotImplementedException();
        }
        public Task<List<UserProfile>> GetUserProfilesAsync()
        {
            throw new NotImplementedException();
        } 
        public Task<List<Contractor>> GetAllContractorAsync()
        {
            throw new NotImplementedException();
        }

        public Post AddPosts(Post newAccount)
        {
            _Db.Posts.Add(newAccount);

            _Db.SaveChanges();

            return _Db.Posts.FirstOrDefault(u => u.PostId == newAccount.PostId);
        }

        public Post DeletePosts(Post Account)
        {
            throw new NotImplementedException();
        }

        public Post GetPosts(Post Account)
        {
            throw new NotImplementedException();
        }

        public Post GetPostsById(string AccountId)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetPostsByUserId(string AccountId)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetPosts()
        {
            return _Db.Posts.ToList();
        }

        public Task<Post> AddPostseAsync(Post newAccount)
        {
            throw new NotImplementedException();
        }

        public Task<Post> DeletePostsAsync(Post Account)
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPostsAsync(Post Account)
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPostsByIdAsync(string AccountId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> GetPostsAsync()
        {
            throw new NotImplementedException();
        }

        public DM AddDMs(DM Account)
        {
            _Db.DMs.Add(Account);

            _Db.SaveChanges();

            return _Db.DMs.FirstOrDefault(u => u.DMId == Account.DMId);
        }

        public DM DeleteDMs(DM Account)
        {
            //_Db.DMs.Add(Account);

            //_Db.SaveChanges();

            //return _Db.DMs.FirstOrDefault(u => u.DMId == Account.DMId);
            throw new NotImplementedException();
        }

        public DM GetDMs(DM Account)
        {
            throw new NotImplementedException();
        }

        public DM GetDMsById(string AccountId)
        {
            throw new NotImplementedException();
        }

        public List<DM> GetDMsByUserId(string AccountId)
        {
            throw new NotImplementedException();
        }

        public List<DM> GetDMs()
        {
            return _Db.DMs.ToList();
        }

        public Task<DM> AddDMsAsync(DM newAccount)
        {
            throw new NotImplementedException();
        }

        public Task<DM> DeleteDMsAsync(DM Account)
        {
            throw new NotImplementedException();
        }

        public Task<DM> GetDMsAsync(DM Account)
        {
            throw new NotImplementedException();
        }

        public Task<DM> GetDMsByIdAsync(string AccountId)
        {
            throw new NotImplementedException();
        }

        public Task<List<DM>> GetDMsAsync()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
