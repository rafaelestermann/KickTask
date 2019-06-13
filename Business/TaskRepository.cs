using KickTask.KickTask.Interfaces;
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
        public List<Task> GetTasksByAccount(long accountId)
        {
            List<Task> tasks = new List<Task>();
            tasks = connection.TaskAccount.Where(taskacc => taskacc.AccountID == accountId).Select(taskaccount => taskaccount.Task).ToList();
            return tasks;
        }

        public void CreateTask(Task task)
        {
            task.StatusID = 3; //für open
            connection.Task.Add(task);
            connection.SaveChanges();
            foreach (var accountId in task.TaskAccountIDS)
            {
                CreateTaskAccount(task.ID, accountId);
            }
        }

        private void CreateTaskAccount(long taskId, int accountId)
        {
            var taskAcc = new TaskAccount()
            {
                TaskID = taskId,
                AccountID = accountId
            };
            connection.TaskAccount.Add(taskAcc);
            connection.SaveChanges();
        }

        public void UpdateTask(Task task)
        {
            if(task.IsFinished)
            {
                task.StatusID = 4; //closed
            }
            else
            {
                task.StatusID = 3; //open
            }
            var dbTask = connection.Task.Where(t => t.ID == task.ID).First();
            dbTask.Name = task.Name;
            dbTask.StatusID = task.StatusID;
            dbTask.TaskAccountIDS = task.TaskAccountIDS;
            dbTask.Text = task.Text;
            connection.SaveChanges();
            connection = new KickTaskConnection();
        }

        public void DeleteTaskById(long id)
        {          
            //TaskAccounts löschen
            var taskAcc = connection.TaskAccount.Where(tacc => tacc.Task.ID == id).ToList();
            foreach(var tacc in taskAcc)
            {
                connection.TaskAccount.Remove(tacc);
                connection.SaveChanges();
            }

            //Task löschen
            var dbTask = connection.Task.Where(t => t.ID == id).First();
            connection.Task.Remove(dbTask);
            connection.SaveChanges();
        }

        public Task GetTasksById(long id)
        {
           return  connection.Task.FirstOrDefault(t => t.ID == id);
        }
    }
}