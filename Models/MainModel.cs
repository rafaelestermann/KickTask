using KickTask.KickTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KickTask.Models
{
    public class MainModel
    {
        public MainModel(IAuthentificationManager authentificationManager)
        {
            this.authentificationManager = authentificationManager;
        }
        
        public IAuthentificationManager authentificationManager { get; set; }
    }
}