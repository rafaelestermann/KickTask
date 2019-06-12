using KickTask.Models;
using System.Collections.Generic;

namespace KickTask.KickTask.Interfaces
{
    public interface ITaskRepository
    {
        List<Task> GetTasksByAccount(long AccountId);
        void CreateTask(Task task);
        void UpdateTaskById(Task task);
        void DeleteTaskById(long id);
        Task GetTasksById(long id);
    }
}