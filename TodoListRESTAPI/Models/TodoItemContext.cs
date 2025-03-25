using Microsoft.EntityFrameworkCore;


//Isaac - DbContext class
namespace TodoListRESTAPI.Models
{
    public class TodoItemContext : DbContext
    {
        public TodoItemContext(DbContextOptions<TodoItemContext> options) : base(options) 
        {
        
        }
        
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
