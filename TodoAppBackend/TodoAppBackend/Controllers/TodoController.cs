using Microsoft.AspNetCore.Mvc;
using TodoAppBackend.Data;
using TodoAppBackend.Models;

namespace TodoAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoRepository _repository;

        public TodoController(TodoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetTodoItems()
        {
            var todos = _repository.GetTodoItems();
            return Ok(todos);
        }

        [HttpPost]
        public IActionResult AddTodoItem([FromBody] TodoItem todo)
        {
            _repository.AddTodoItem(todo);
            return Ok(todo);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTodoItem(int id, [FromBody] TodoItem todo)
        {
            var existingTodo = _repository.GetTodoItem(id);
            if (existingTodo == null)
            {
                return NotFound();
            }

            existingTodo.Description = todo.Description;
            existingTodo.Completed = todo.Completed;

            _repository.UpdateTodoItem(existingTodo);
            return Ok(existingTodo);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTodoItem(int id)
        {
            var existingTodo = _repository.GetTodoItem(id);
            if (existingTodo == null)
            {
                return NotFound();
            }

            _repository.DeleteTodoItem(id);
            return NoContent();
        }
    }
}


