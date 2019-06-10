using KickTask.Models;

namespace KickTask.KickTask.Interfaces
{
    public interface IAccountRepository
    {
        void InsertAccount(Account account);
        Account GetAccountByEmail(string email);
        Account VerifyAccount(string id);
        bool IsEmailExisting(string emailId);
    }
}