using Lesson2.Model;
using Lesson2.Services;
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
        public ActionResult<IEnumerable<Tasks>> getTasks()
        {
            return _taskService.GetAllTasks();
        }
        //api/Task/status
        [HttpGet("{status}")]
        public ActionResult<List<Tasks>> getTask(string status)
        {
            return _taskService.GetTasksByStatus(status);
            //return task;
        }
        //http://localhost:5236/api/Task
        //{ "priority": "do home work😰😰","dueTime": "2024-09-11","status": "pending"}
        [HttpPost]
        public ActionResult<List<Tasks>> AddTask([FromBody] Tasks newTask)
        {
            return _taskService.AddTask(newTask);
        }
        //http://localhost:5236/api/Task/pending/3
        [HttpPut("{status}/{id}")]
        public ActionResult<Tasks> UpdateTaskById(string status, int id)
        {
            return _taskService.UpdateTaskById(status, id);
        }
        //http://localhost:5236/api/Task/3
        [HttpDelete("{id}")]
        public ActionResult<Tasks> DeleteTaskById(int id)
        {
            return _taskService.DeleteTaskById(id);
        }
    }
}
