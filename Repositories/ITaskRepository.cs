using Microsoft.AspNetCore.Mvc;
using Task = TaskManagement.Models.Task;

namespace TaskManagement.Repositories;

public interface ITaskRepository
{
    Task<IEnumerable<Task>> GetTasksAsync();
    Task CreateTask(Task task);
    void DeleteTask(int id);
    Task UpdateTask(int id, Task newTask);
}