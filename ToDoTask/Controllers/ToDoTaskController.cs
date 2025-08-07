using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using ToDoTask.Application.Services;
using ToDoTask.Contracts;
using ToDoTask.Domain.Models;

namespace ToDoTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoTaskController : ControllerBase
    {
        private readonly IToDoTaskService _toDoTaskService;
        public ToDoTaskController(IToDoTaskService toDoTaskService) 
        {
            _toDoTaskService = toDoTaskService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ToDoTaskResponse>>> GetBooks()
        {
            var tasks = await _toDoTaskService.GetAllTasks();

            var response = tasks.Select(b => new ToDoTaskResponse(b.Id, b.Name, b.Description, b.IsComplited, b.DateCreated));

            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBooks([FromBody] ToDoTaskRequest request)
        {
            var (task, error) = Domain.Models.Task.Create(
                Guid.NewGuid(),
                request.Name,
                request.Descriptions,
                request.IsComplited,
                request.DateCreated);

            if(!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            } 

            var toDoTaskId = await _toDoTaskService.CreateTask(task);
            return Ok(toDoTaskId);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<Guid>> UpdateToDoTask(Guid id, [FromBody] ToDoTaskRequest request)
        {
            var ToDoTaskId = await _toDoTaskService.UpdateTask(id, request.Name, request.Descriptions, request.IsComplited, request.DateCreated);
            return Ok(ToDoTaskId);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<Guid>> DeleteToDoTask(Guid id, [FromBody] ToDoTaskRequest request)
        {
            return Ok(await _toDoTaskService.DeleteTask(id));
        }
    }
}
