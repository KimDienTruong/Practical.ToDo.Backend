using backend.Data;
using backend.DTO;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        private readonly ToDoService _toDoService;
        public ToDosController(ApplicationDbContext dbContext)
        {
            _toDoService = new ToDoService(dbContext);
        }

        [HttpGet]
        public async Task<IActionResult> GetToDos(int pageIndex = 0, int pageSize = 5)
        {
            ICollection<ToDoTask> toDoTasks = await _toDoService.GetToDoTasksWithPagination(pageIndex, pageSize);

            if (toDoTasks.Count == 0)
            {
                return NotFound();
            }

            return Ok(toDoTasks);
        }

        [HttpPost]
        public async Task<IActionResult> CreateToDo(CreateToDoDTO createToDoDTO)
        {
            ToDoTask? newToDoTask = await _toDoService.CreateToDo(createToDoDTO);

            if(newToDoTask ==  null)
            {
                return BadRequest();
            }

            return Created();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateToDo(string id, UpdateToDoDto updateToDoDto)
        {
            ToDoTask? toDoTask = await _toDoService.UpdateToDo(id, updateToDoDto);

            if (toDoTask == null)
            {
                return BadRequest();
            }

            return Ok(toDoTask);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteToDo(string id)
        {
            return await _toDoService.DeleteToDo(id) ? Ok() : BadRequest();
        }
    }
}
