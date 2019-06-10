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

namespace KickTask.Controllers
{
    public class AccountController : Controller
    {
        string message = "";
        bool status = false;

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Exclude = "IsEmailVerified, ActivationCode")] Account account)
        {
            //Model Validierung
            if (ModelState.IsValid)
            {
                #region email already exists
                var isExist = IsEmailAlreadyExisting(account.EmailID);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExists", "There is already an account with this email");
                    return View(account);
                }
                #endregion

                if (!account.AgreedPolicy)
                {
                    ModelState.AddModelError("PolicyNotAgreed", "Your agreement with our policy is required");
                    return View(account);
                }
                #region generate Activation Code
                account.ActivationCode = Guid.NewGuid().ToString();
                #endregion

                #region password hashing
                account.Password = Crypto.Hash(account.Password);
                account.ConfirmPassword = Crypto.Hash(account.ConfirmPassword);
                #endregion

                account.IsEmailVerified = false;

                #region save to database
                using (KickTaskConnection dc = new KickTaskConnection())
                {
                    dc.Account.Add(account);
                    dc.SaveChanges();

                    //Send Email to User
                    SendVerificationLinkEmail(account.EmailID, account.ActivationCode.ToString());
                    message = "Account activation link " +
                        " has been sent to your email " + account.EmailID;
                    status = true;
                    NotificationCenter.AddRegistrationSuccessfull(message);
                }
                #endregion
                ViewBag.Message = message;
                ViewBag.Status = status;
            }
            return View(account);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountLogin accountLogin)
        {
            if (accountLogin == null || accountLogin.Email == null || accountLogin.Password == null)
            {
                return View(accountLogin);
            }
            using (KickTaskConnection dc = new KickTaskConnection())
            {
                var account = dc.Account.FirstOrDefault(c => c.EmailID == accountLogin.Email);
                if (account != null)
                {
                    if (string.Compare(Crypto.Hash(accountLogin.Password), account.Password) == 0)
                    {
                        if (!account.IsEmailVerified)
                        {
                            ModelState.AddModelError("UserExists", "Please verify your account by checking your emails");
                            return View(accountLogin);
                        }
                        int timeout = accountLogin.RememberMe ? 525600 : 20;
                        var ticket = new FormsAuthenticationTicket(accountLogin.Email, accountLogin.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);

                        var container = Builder.Container;
                        var model = container.Resolve<MainModel>();
                        model.LoggedInAccount = account;
                        ViewBag.Status = true;
                        ViewBag.Message = "Login successfully";
                        NotificationCenter.AddLoginNotification("Welcome " + account.Fullname);
                    }
                }
                else
                {
                    ModelState.AddModelError("UserExists", "Either your email or your password is wrong, try again!");

                }
            }
            return View(accountLogin);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            var container = Builder.Container;
            var model = container.Resolve<MainModel>();
            model.LoggedInAccount = null;
            NotificationCenter.AddLogoutNotification();
            return RedirectToAction("Main", "Main");
        }


        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            bool status = false;
            using (KickTaskConnection dc = new KickTaskConnection())
            {
                dc.Configuration.ValidateOnSaveEnabled = false;
                var account = dc.Account.Where(a => a.ActivationCode == new Guid(id).ToString()).FirstOrDefault();
                if (account != null)
                {
                    account.IsEmailVerified = true;
                    dc.SaveChanges();
                    status = true;
                    var container = Builder.Container;
                    var model = container.Resolve<MainModel>();
                    model.LoggedInAccount = account;
                    NotificationCenter.AddVerificationSuccessfull("Welcome to ashton " + account.Fullname);
                }

                else
                {
                    ViewBag.Message = "invalid request";
                }
            }

            ViewBag.Status = status;
            return RedirectToAction("Main", "Main");
        }




        [NonAction]
        public bool IsEmailAlreadyExisting(string emailId)
        {
            using (KickTaskConnection dc = new KickTaskConnection())
            {
                var v = dc.Account.Where(x => x.EmailID == emailId).FirstOrDefault();
                return v != null;
            };
        }

        [NonAction]
        public void SendVerificationLinkEmail(string emailId, string activationcode)
        {
            var verifyUrl = "/Account/VerifyAccount?id=" + activationcode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("noreply.ashton@gmail.com", "Kicktask App");
            var toEmail = new MailAddress(emailId);
            var fromEmailPassword = "Waldweg1313";
            string subject = "Your account is successfuly created!";
            string body = "<br/><br/>We are exited to tell you that your kicktask account is" +
                " Successfully created. Please click on the below link to verify your account" +
                " <br/><br/><a href='" + link + "'>" + link + "</a> ";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }
    }
}
