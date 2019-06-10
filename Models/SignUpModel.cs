using KickTask.Database;
using System.Collections.Generic;
using System.Globalization;
using System;
using KickTask.KickTask.Interfaces;

namespace KickTask.Models
{
    public class SignUpModel
    {
        private readonly IDatabaseHandler _databaseHandler;

        public SignUpModel(IDatabaseHandler databaseHandler)
        {
            _databaseHandler = databaseHandler;
        }

        public void RegisterWorker(Account account)
        {
            _databaseHandler.InsertAccount(account);
        }    
    }
}

