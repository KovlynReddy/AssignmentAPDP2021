using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTemplate02.Data.DataModels.InternalModels;
using WebTemplate02.Data.DataModels.ProfileModels;

namespace WebTemplate02.Data.Interfaces
{
    public interface IUserRepository
    {

        #region UserAccounts

        UserAccount AddUserAccount(UserAccount newAccount);
        UserAccount DeleteUserAccount(UserAccount Account);
        UserAccount GetUserAccount(UserAccount Account);
        UserAccount GetUserAccountById(string AccountId);
        List<UserAccount> GetUserAccounts();        
        
        Task<UserAccount> AddUserAccountAsync(UserAccount newAccount);
        Task<UserAccount> DeleteUserAccountAsync(UserAccount Account);
        Task<UserAccount> GetUserAccountAsync(UserAccount Account);
        Task<UserAccount> GetUserAccountByIdAsync(string AccountId);
        Task<List<UserAccount>> GetUserAccountsAsync(); 

        #endregion      
        
        #region UserProfiles

        UserProfile AddUserProfile(UserProfile newAccount);
        UserProfile DeleteUserProfile(UserProfile Account);
        UserProfile GetUserProfile(UserProfile Account);
        UserProfile GetUserProfileById(string AccountId);
        List<UserProfile> GetUserProfile();        
        
        Task<UserProfile> AddUserProfileAsync(UserProfile newAccount);
        Task<UserProfile> DeleteUserProfileAsync(UserProfile Account);
        Task<UserProfile> GetUserProfileAsync(UserProfile Account);
        Task<UserProfile> GetUserProfileByIdAsync(string AccountId);
        Task<List<UserProfile>> GetUserProfilesAsync(); 

        #endregion    
        
        #region Transactions

        Transaction AddTransaction(Transaction newAccount);
        Transaction DeleteTransaction(Transaction Account);
        Transaction GetTransaction(Transaction Account);
        Transaction GetTransactionById(string AccountId);
        List<Transaction> GetAllTransactions();        
        
        Task<Transaction> AddTransactionAsync(Transaction newAccount);
        Task<Transaction> DeleteTransactionAsync(Transaction Account);
        Task<Transaction> GetTransactionAsync(Transaction Account);
        Task<Transaction> GetTransactionIdAsync(string AccountId);
        Task<List<Transaction>> GetAllTransactionAsync(); 

        #endregion
        
        #region Constractors

        Contractor AddContractor(Contractor newAccount);
        Contractor DeleteContractor(Contractor Account);
        Contractor GetContractor(Contractor Account);
        Contractor GetContractorById(string AccountId);
        List<Contractor> GetAllContractors();        
        
        Task<Contractor> AddContractorAsync(Contractor newAccount);
        Task<Contractor> DeleteContractorAsync(Contractor Account);
        Task<Contractor> GetContractorAsync(Contractor Account);
        Task<Contractor> GetContractorIdAsync(string AccountId);
        Task<List<Contractor>> GetAllContractorAsync();

        #endregion

        #region Posts
        Post AddPosts(Post newAccount);
        Post DeletePosts(Post Account);
        Post GetPosts(Post Account);
        Post GetPostsById(string AccountId);
        List<Post> GetPostsByUserId(string AccountId);
        List<Post> GetPosts();

        Task<Post> AddPostseAsync(Post newAccount);
        Task<Post> DeletePostsAsync(Post Account);
        Task<Post> GetPostsAsync(Post Account);
        Task<Post> GetPostsByIdAsync(string AccountId);
        Task<List<Post>> GetPostsAsync();
        #endregion

        #region DMs

        DM AddDMs(DM newAccount);
        DM DeleteDMs(DM Account);
        DM GetDMs(DM Account);
        DM GetDMsById(string AccountId);
        List<DM> GetDMsByUserId(string AccountId);
        List<DM> GetDMs();

        Task<DM> AddDMsAsync(DM newAccount);
        Task<DM> DeleteDMsAsync(DM Account);
        Task<DM> GetDMsAsync(DM Account);
        Task<DM> GetDMsByIdAsync(string AccountId);
        Task<List<DM>> GetDMsAsync();

        #endregion
    }
}
