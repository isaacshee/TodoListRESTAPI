using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoListRESTAPI.Models;

namespace TodoListRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly TodoItemContext _todoItemContext;
        public TodoItemController(TodoItemContext todoItemContext)
        {
            _todoItemContext = todoItemContext;
        }

        //ISAAC - GET API that returns all todo items in the list
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            //ISAAC - if table is empty, return NotFound error code
            if (_todoItemContext.TodoItems == null)
            {
                return NotFound();
            }
            //ISAAC - else, return list
            return await _todoItemContext.TodoItems.ToListAsync();
        }

        //ISAAC - GET API that returns one todo item based on id
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
        {
            //ISAAC - if table is empty, return NotFound error code
            if (_todoItemContext.TodoItems == null)
            {
                return NotFound();
            }

            //ISAAC - assign variable to id passed from parameter and check if it exists
            var todoItem = await _todoItemContext.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }
            //ISAAC - else, return the item
            else
            {
                return todoItem;
            }
        }

        //ISAAC - POST API that inserts one todo item
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoitem) 
        {
            //ISAAC - taking parameter todoitem from frontend and adding it to the database
            _todoItemContext.TodoItems.Add(todoitem);
            await _todoItemContext.SaveChangesAsync();

            //ISAAC - returning the same object that was added with its id
            return CreatedAtAction("GetTodoItem", new {id = todoitem.ID}, todoitem);
        }

        //ISAAC - PUT API that edits one todo item
        [HttpPut("{id}")]
        public async Task<ActionResult> PutTodoItem(int id, TodoItem todoitem)
        {
            //ISAAC - requires two things: 1) id of the todo item & 2) complete object (todo item) in order to change values of the selected object
            if (id != todoitem.ID)
            {
                return BadRequest();
            }

            //ISAAC - trying to update the state of a particular todo item
            _todoItemContext.Entry(todoitem).State = EntityState.Modified;
            try
            {
                await _todoItemContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            //ISAAC- return Code: 204 No Content - indicating a successful edit
            return NoContent();
        }

        //ISAAC - DELETE API that removes one specified todo item
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodoItem(int id) 
        {
            //ISAAC - if table is empty, return NotFound error code
            if (_todoItemContext.TodoItems == null) 
            {
                return NotFound();
            }
            //ISAAC - assign variable to id passed from parameter and check if it exists
            var todoItem = await _todoItemContext.TodoItems.FindAsync(id);

            if (todoItem == null)
            { 
                return NotFound();
            }
            //ISAAC - else, remove the item and savechanges
            else
            {
                _todoItemContext.TodoItems.Remove(todoItem);
                await _todoItemContext.SaveChangesAsync();
            }

            //ISAAC- return Code: 204 No Content - indicating a successful delete
            return NoContent();
        }
    }
}
