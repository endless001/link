using Account.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.API.Services
{
    public interface IAccountService
    {
        Task<AccountModel> CheckOrCreateAsync(string phone);
        Task<AccountModel> SearchAsync(string phone);
        Task<AccountModel> SignInPasswordAsync(string accountName,string password);
        Task<bool> RegisterPhoneAsync(AccountModel accountModel);
        Task<bool> RegisterEmailAsync(AccountModel accountEntity);
    }
}
