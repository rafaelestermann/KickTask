using KickTask.Models;
using KickTask.Modules;
using Autofac;
using System;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using KickTask.Models.Extendet;
using System.Web.Helpers;
using KickTask.KickTask;
using KickTask.KickTask.Interfaces;

namespace KickTask.Controllers
{
    public class PartnerController : Controller
    {
        IContainer container = Builder.Container;
        IDatabaseHandler databaseHandler;
        IAuthentificationManager authentificationManager;

        public PartnerController()
        {
            databaseHandler = container.Resolve<IDatabaseHandler>();
            authentificationManager = container.Resolve<IAuthentificationManager>();
        }

        [HttpGet]
        public ActionResult Partners()
        {
            var model = databaseHandler.AccountRepository.GetAccountsByAccountId(authentificationManager.SignedInAccount.ID);
            return View(model);
        }
    }
}
