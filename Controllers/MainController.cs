using System.Collections.Generic;
using System.Web.Mvc;
using KickTask.KickTask;
using KickTask.Models;
using KickTask.Modules;
using Autofac;
using Autofac.Core;
using System.Web.UI;
using System.Linq;

namespace KickTask.Controllers
{
    public class MainController : Controller
    {

        public ActionResult Main()
        {

            var container = Builder.Container;
            var model = container.Resolve<MainModel>();
            UpdateModel(model);
            if (NotificationCenter.Notifications != null && NotificationCenter.Notifications.Any())
            {
                ViewBag.JavascriptFunctions = NotificationCenter.Notifications;
                NotificationCenter.Notifications = new List<string>();
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Account()
        {
            var container = Builder.Container;
            var model = container.Resolve<MainModel>();   
            return View(model);
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            var model = Builder.Container.Resolve<SignUpModel>();
            return View("SignUp", model);
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            var model = Builder.Container.Resolve<SignInModel>();
            return View("SignIn", model);
        }
    }
}