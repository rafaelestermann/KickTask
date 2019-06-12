using System.Collections.Generic;
using System.Web.Mvc;
using KickTask.KickTask;
using KickTask.Models;
using KickTask.Modules;
using Autofac;
using Autofac.Core;
using System.Web.UI;
using System.Linq;
using KickTask.KickTask.Interfaces;

namespace KickTask.Controllers
{
    public class MainController : Controller
    {

        IContainer container = Builder.Container;
        IDatabaseHandler databaseHandler;
        IAuthentificationManager authentificationManager;

        public MainController()
        {
            databaseHandler = container.Resolve<IDatabaseHandler>();
            authentificationManager = container.Resolve<IAuthentificationManager>();
        }

        public ActionResult Main()
        {
            if (NotificationCenter.Notifications != null && NotificationCenter.Notifications.Any())
            {
                ViewBag.JavascriptFunctions = NotificationCenter.Notifications;
                NotificationCenter.Notifications = new List<string>();
            }

            var model = new MainModel(authentificationManager);
            return View(model);
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View("SignUp");
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View("SignIn");
        }
    }
}