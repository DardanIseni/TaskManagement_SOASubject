using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagement.db;
using TaskManagement.Repositories;
using TaskManagement.Services;
using Task = TaskManagement.Models.Task;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly AppDbContext _context;
        private readonly ITaskService _taskService;

        public TaskController(AppDbContext context, ITaskRepository taskRepository, ITaskService taskService)
        {
            _taskRepository = taskRepository;
            _context = context;
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Task>>> GetTask()
        {
            var tasks =  await _taskService.GetTasks();
            return Ok(tasks);
        }

        [HttpPost]
        public IActionResult Create(Task task)
        {
            var newTask = _taskService.CreateTask(task);
            if (newTask.Equals(null))
            {
                return BadRequest();
            }
            
            var res = new
            {
                Message = "Task created successfully",
                Task = newTask
            };
            return Ok(res);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Task new_task)
        {
            try
            {
                _taskService.UpdateTask(id,new_task);
                var res = new
                {
                    Message = "Task updated successfully",
                    Task = _taskService.UpdateTask(id,new_task)
                };
                return Ok(res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            try
            {
                _taskService.DeleteTask(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }
    }
}
