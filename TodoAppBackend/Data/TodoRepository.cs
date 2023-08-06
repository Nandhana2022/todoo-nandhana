using System.Collections.Generic;
using System.Linq;
using TodoAppBackend.Data;
using TodoAppBackend.Models;

namespace TodoAppBackend.Data
{
    public class TodoRepository
    {
        private readonly TodoDbContext _dbContext;

        public TodoRepository(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TodoItem> GetTodoItems()
        {
            return _dbContext.TodoItems.ToList();
        }

        public void AddTodoItem(TodoItem todo)
        {
            _dbContext.TodoItems.Add(todo);
            _dbContext.SaveChanges();
        }

        public TodoItem GetTodoItem(int id)
        {
            return _dbContext.TodoItems.FirstOrDefault(t => t.Id == id);
        }

        public void UpdateTodoItem(TodoItem todo)
        {
            _dbContext.TodoItems.Update(todo);
            _dbContext.SaveChanges();
        }

        public void DeleteTodoItem(int id)
        {
            var todo = _dbContext.TodoItems.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                _dbContext.TodoItems.Remove(todo);
                _dbContext.SaveChanges();
            }
        }
    }
}
