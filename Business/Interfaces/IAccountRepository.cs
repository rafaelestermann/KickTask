using KickTask.Models;
using System.Collections.Generic;

namespace KickTask.KickTask.Interfaces
{
    public interface IAccountRepository
    {
        void InsertAccount(Account account);
        Account GetAccountByEmail(string email);
        Account VerifyAccount(string id);
        bool IsEmailExisting(string emailId);
        List<Account> GetAllAccounts();
        List <Account> GetAccountsByAccountId(long iD);
        Account GetAccountById(long id);
        void UpdateAccount(Account account);
    }
}