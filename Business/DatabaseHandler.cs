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
        public ITaskRepository TaskRepository { get; set; }
        public IAccountRepository AccountRepository { get; set; }

        public DatabaseHandler()
        {
            var connection = new KickTaskConnection();
            TaskRepository = new TaskRepository(connection);
            AccountRepository = new AccountRepository(connection);
        }
    }
}