using KickTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KickTask.Database
{
    public class AccountService
    {
        public void CreateAccount(Account account)
        {
            //using (kicktaskdatabaseEntities context = new kicktaskdatabaseEntities())
            //{
            //    context.Account.Add(account);
            //    context.SaveChanges();
            //}
        }
        public Account GetAccountByUsernameAndPassword(string username, string password)
        {
            //Account account;
            //using (kicktaskdatabaseEntities context = new kicktaskdatabaseEntities())
            //{
            //    account = context.Account.Where(acc => acc.Username == username && acc.Password == password).FirstOrDefault();
            //}
            return new Account();
        }
    }
}