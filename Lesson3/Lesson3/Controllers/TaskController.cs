using Lesson3.Model;
using Lesson3.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lesson1.NewFolder
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITasksService _taskService;
        public TaskController(ITasksService taskService)
        {
            _taskService = taskService;
        }

        private static List<Tasks> tasks = new List<Tasks>()
        {
            new Tasks {id = 1, priority = "go to sleep", dueTime = new DateTime(2024-09-09), status = "pending"},
            new Tasks {id = 2, priority = "go to learn", dueTime = new DateTime(2024-08-09), status = "pending"},
            new Tasks {id = 3, priority = "do home work", dueTime = new DateTime(2024-07-09), status = "pending"}
        };

        //api/Task
        [HttpGet]
        public IActionResult getTasks()
        {
            var task = _taskService.GetAllTasks();
            return Ok(task);
        }
        
        //http://localhost:5236/api/Task
        //{ "priority": "do home work😰😰","dueTime": "2024-09-11","status": "pending"}
        [HttpPost]
        public IActionResult AddTask(Tasks newTask)
        {
            if (newTask == null)
            {
                return BadRequest("Task is null");
            }
            _taskService.AddTask(newTask);
            return CreatedAtAction(nameof(getTasks), new { id = newTask.id }, newTask);
        }


        //http://localhost:5236/api/Task/pending/3
        [HttpPut("{status}/{id}")]
        public IActionResult UpdateTaskById([FromBody] Tasks task)
        {
            _taskService.UpdateTaskById(task);
            return NoContent();
        }
        //http://localhost:5236/api/Task/3
        [HttpDelete("{id}")]
        public IActionResult DeleteTaskById(int id)
        {
             _taskService.DeleteTaskById(id);
            return NoContent();
        }
    }
}
