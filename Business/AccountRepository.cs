using KickTask.KickTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using KickTask.Models;
using System.Web.Helpers;

namespace KickTask.KickTask
{
    public class AccountRepository : IAccountRepository
    {
        KickTaskConnection connection;
        public AccountRepository(KickTaskConnection connection)
        {
            this.connection = connection;
        }

        public Account GetAccountByEmail(string email)
        {
            return connection.Account.FirstOrDefault(c => c.EmailID == email);
        }

        public Account GetAccountById(long id)
        {
            var account = connection.Account.FirstOrDefault(c => c.ID == id);
            account.OpenTasks = connection.TaskAccount.Where(taskacc => taskacc.AccountID == id && taskacc.Task.Status.StatusText == "open").Count();
            account.ClosedTasks = connection.TaskAccount.Where(taskacc => taskacc.AccountID == id && taskacc.Task.Status.StatusText == "closed").Count();
            return account;
        }

        public List<Account> GetAccountsByAccountId(long iD)
        {
            return connection.Account.ToList();
            //var taskAccounts = connection.TaskAccount.Where(acc => acc.AccountID == iD);
            //return taskAccounts.Any(taskAcc => taskAcc.AccountID != iD);
        }

        public List<Account> GetAllAccounts()
        {
            return connection.Account.ToList();
        }

        public void InsertAccount(Account account)
        {
            connection.Account.Add(account);
            connection.SaveChanges();
        }

        public bool IsEmailExisting(string emailId)
        {
            return connection.Account.Where(x => x.EmailID == emailId).FirstOrDefault() != null;
        }

        public void UpdateAccount(Account account)
        {
            using (var conn = new KickTaskConnection())
            {
                var result = conn.Account.SingleOrDefault(acc => acc.ID == account.ID);
                if (result != null)
                {
                    result.Fullname = account.Fullname;
                    result.Username = account.Username;
                    result.EmailID = account.EmailID;
                    result.Password = account.Password;
                    result.ConfirmPassword = account.Password;

                    conn.SaveChanges();
                    connection = new KickTaskConnection();
                }
            }

        }

        public Account VerifyAccount(string id)
        {
            var account = connection.Account.Where(a => a.ActivationCode == new Guid(id).ToString()).FirstOrDefault();
            if (account != null)
            {
                account.IsEmailVerified = true;
                connection.SaveChanges();
            }
            return account;
        }
    }
}