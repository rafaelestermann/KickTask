using KickTask.Models;
using KickTask.Modules;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using KickTask.Models.Extendet;
using System.Web.Helpers;
using KickTask.KickTask;
using KickTask.KickTask.Interfaces;

namespace KickTask.Controllers
{
    public class TaskController : Controller
    {
        IContainer container = Builder.Container;
        IDatabaseHandler databaseHandler;
        IAuthentificationManager authentificationManager;
        public TaskController()
        {
            databaseHandler = container.Resolve<IDatabaseHandler>();
            authentificationManager = container.Resolve<IAuthentificationManager>();
        }

        [HttpGet]
        public ActionResult Tasks()
        {            
            List<Task> tasks = databaseHandler.TaskRepository.GetTasksByAccount(authentificationManager.SignedInAccount.ID);
            return View(tasks);
        }

        [HttpPost]
        public ActionResult SaveTaskStep(string teext, Task model)
        {
            var taskStep = new Taskstep();
            taskStep.Text = "ff";
          //  model.Taskstep.Add(taskStep);
            return View("CreateTask");
        }


        [HttpGet]   
        public ActionResult CreateTask()
        {
            var model = new Task();
            return View(model);
        }

        [HttpGet]
        public ActionResult TaskDetail(long ID)
        {
            var model = databaseHandler.TaskRepository.GetTasksById(ID);
            return View(model);
        }

        [HttpGet]
        public ActionResult DeleteTask(int ID)
        {
            databaseHandler.TaskRepository.DeleteTaskById(ID);
            List<Task> tasks = databaseHandler.TaskRepository.GetTasksByAccount(authentificationManager.SignedInAccount.ID);
            return View("Tasks", tasks);
        }

        [HttpPost]
        public ActionResult CreateTask(Task model)
        {
            //VALIDIERUNG
            databaseHandler.TaskRepository.CreateTask(model);
            List<Task> tasks = databaseHandler.TaskRepository.GetTasksByAccount(authentificationManager.SignedInAccount.ID);
            return View("Tasks",tasks);
        }
    }
}
