using KickTask.KickTask.Interfaces;
using KickTask.Database;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using KickTask.Models;

namespace KickTask.KickTask
{
    public class DatabaseHandler : IDatabaseHandler
    {
        public void InsertAccount(Account worker)
        {
            //using (ISession session = NhibernateSession.OpenSession())
            //using (ITransaction transaction = session.BeginTransaction())
            //{
            //    try
            //    {
            //        session.Save(worker);
            //        transaction.Commit();
            //    }
            //    catch (Exception)
            //    {
            //        transaction.Rollback();
            //    }
            //}
        }
    }           
}