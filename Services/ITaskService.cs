using Task = TaskManagement.Models.Task;

namespace TaskManagement.Services;

public interface ITaskService
{
    Task<IEnumerable<Task>> GetTasks();
    
    //generate other methods
    
    Task CreateTask(Task task);
    Task UpdateTask(int id, Task task);
    void DeleteTask(int id);
    
    

}