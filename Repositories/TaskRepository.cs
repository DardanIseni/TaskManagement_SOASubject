using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagement.db;
using Task = TaskManagement.Models.Task;

namespace TaskManagement.Repositories;

public class TaskRepository: ITaskRepository
{

    private AppDbContext _appDbContext;

    public TaskRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<Task>> GetTasksAsync()
    {
        return await _appDbContext.Tasks.ToListAsync();
    }

    public void DeleteTask(int id)
    {
        var task = _appDbContext.Tasks.FirstOrDefault(t => t.Id == id);
        _appDbContext.Tasks.Remove(task);
        _appDbContext.SaveChanges();

    }
    public Task CreateTask(Task newTask)
    {
        Task task = new Task
        {
            Name = newTask.Name,
            Description = newTask.Description
        };
        _appDbContext.Tasks.Update(task);
        _appDbContext.SaveChanges();
        return task;
    }

    public Task UpdateTask(int id, Task newTask)
    {
        var task = _appDbContext.Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) return null!;
        task.Name = newTask.Name;
        task.Description = newTask.Description;
        _appDbContext.Tasks.Update(task);
        _appDbContext.SaveChanges();
        return task;
    }
    
    
}