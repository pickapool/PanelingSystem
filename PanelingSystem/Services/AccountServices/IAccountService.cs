using Microsoft.AspNetCore.Mvc;
using PanelingSystem.Models;

namespace PanelingSystem.Services.AccountServices
{
    public interface IAccountService
    {
        Task<IEnumerable<UserAccountModel>> GetAccounts();
        Task<UserAccountModel> GetUserAccountModel(int id);
        Task<UserAccountModel> PutUserAccountModel(int id, UserAccountModel userAccountModel);
        Task<UserAccountModel> DeleteUserAccountModel(int id);
        Task<UserAccountModel> PostUserAccountModel(UserAccountModel userAccountModel);
        Task<UserAccountModel> Authenticate(string username, string password);
        Task<IEnumerable<UserAccountModel>> GetStudentsAccount();
    }
}
