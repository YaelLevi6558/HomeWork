using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ex2.Services;
using ex2.Models;

namespace ex2.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksServices _taskService;

        public TasksController(ITasksServices taskService)
        {
            _taskService = taskService;
        }


        [HttpPost]
        public IActionResult Add([FromBody] Tasks task)
        {
            try
            {
                _taskService.Add(task);
                return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }      
        }
        [HttpPost("addByUser")]
        public IActionResult addByUser([FromBody] Tasks task)
        {
            try
            {
                _taskService.addByUser(task);
                return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        public IActionResult Get()
        {
            var task = _taskService.Get();
            return Ok(task);
        } 
        [HttpGet("{name}")]
        public ActionResult GetByUserName(string name)
        {
            var userName = _taskService.GetAllGetByUserName(name);
            if (userName == null || userName.Count == 0)
                return NotFound("לא נמצא משימות למשתמש");
            return Ok(userName);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Tasks task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }
            _taskService.Update(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _taskService.Delete(id);
            return NoContent();
        }

    }
}
