using TaskManagement.Repositories;
using Task = TaskManagement.Models.Task;

namespace TaskManagement.Services;

public class TaskService: ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }


    public Task<IEnumerable<Task>> GetTasks()
    {
        return   _taskRepository.GetTasksAsync();
    }

    public Task CreateTask(Task task)
    {
        return _taskRepository.CreateTask(task);
    }

    public Task UpdateTask(int id, Task task)
    {
        return _taskRepository.UpdateTask(id, task);
    }

    public void DeleteTask(int id)
    {
        _taskRepository.DeleteTask(id);
    }
}