using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KickTask.Models;

namespace KickTask.KickTask.Interfaces
{
    public interface IDatabaseHandler
    {
        ITaskRepository TaskRepository { get; set; }
        IAccountRepository AccountRepository { get; set; }
    }
}
