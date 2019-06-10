using KickTask.KickTask.Interfaces;
using KickTask.Database;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using KickTask.Models;

namespace KickTask.KickTask
{
    public class TaskRepository : ITaskRepository
    {
        KickTaskConnection connection;
        public TaskRepository(KickTaskConnection connection)
        {
            this.connection = connection;
        }
        public List<Task> GetTasksByAccount()
        {
            return null;
        }
    }
}