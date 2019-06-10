using KickTask.Models;
using System.Collections.Generic;

namespace KickTask.KickTask.Interfaces
{
    public interface ITaskRepository
    {
        List<Task> GetTasksByAccount();
    }
}