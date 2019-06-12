﻿using KickTask.KickTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using KickTask.Models;

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