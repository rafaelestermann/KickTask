﻿using KickTask.KickTask.Interfaces;
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

        public void UpdateTaskById(Task task)
        {
            var dbTask = connection.Task.Where(t => t.ID == task.ID).First();
            dbTask = task;
            connection.SaveChanges();
        }

        public void DeleteTaskById(long id)
        {
            //Tasksteps löschen
            var tasksteps = connection.Taskstep.Where(tstep => tstep.TaskID == id).ToList();
            foreach (var taskstep in tasksteps)
            {
                connection.Taskstep.Remove(taskstep);
                connection.SaveChanges();
            }

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