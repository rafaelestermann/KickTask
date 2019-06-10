using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace KickTask.Database
{
    public class TaskService
    {
        public void CreateTask(Task task)
        {
            //using (kicktaskdatabaseEntities context = new kicktaskdatabaseEntities())
            //{
            //    context.Task.Add(task);
            //    context.SaveChanges();
            //}
        }
        public List<Task> GetTasksByUser(long accountId)
        {
            List<Task> tasks = new List<Task>();
            //using (kicktaskdatabaseEntities context = new kicktaskdatabaseEntities())
            //{
            //    tasks = context.TaskAccount.Where(taskacc => taskacc.AccountID == accountId).Select(taskaccount => taskaccount.Task).ToList();
            //}
            return tasks;
        }

        public void UpdateTaskById(Task task)
        {
            //using (kicktaskdatabaseEntities context = new kicktaskdatabaseEntities())
            //{
            //    var dbTask = context.Task.Where(t => t.ID == task.ID).First();
            //    dbTask = task;
            //    context.SaveChanges();
            //}
        }

        public void DeleteTaskById(long id)
        {      
            //using (kicktaskdatabaseEntities context = new kicktaskdatabaseEntities())
            //{
            //    //Tasksteps löschen
            //    var tasksteps = context.Taskstep.Where(tstep => tstep.TaskID == id).ToList();
            //    foreach (var taskstep in tasksteps)
            //    {
            //        context.Taskstep.Remove(taskstep);
            //        context.SaveChanges();
            //    }

            //    //Task löschen
            //    var dbTask = context.Task.Where(t => t.ID == id).First();
            //    context.Task.Remove(dbTask);
            //    context.SaveChanges();
            //}
        }
    }
}