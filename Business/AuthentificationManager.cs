using KickTask.KickTask.Interfaces;
using KickTask.Database;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using KickTask.Models;
using KickTask.Models.Extendet;

namespace KickTask.KickTask
{
    public class AuthentificationManager : IAuthentificationManager
    {
        public Account SignedInAccount { get; set; }

        public void SignIn(Account account)
        {
            SignedInAccount = account;
        }

  
        public void SignOut()
        {
            SignedInAccount = null;
        }
    }
}