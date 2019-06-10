using KickTask.KickTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KickTask.Models
{
    public class MainModel
    {
        private readonly IDatabaseHandler _databaseHandler;

        public MainModel(IDatabaseHandler databaseHandler)
        {
            _databaseHandler = databaseHandler;
        }
        
        public Account LoggedInAccount { get; set; }
    }
}