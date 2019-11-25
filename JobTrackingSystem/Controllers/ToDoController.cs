using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobTrackingSystem.Models;
using JobTrackingSystem.Data;
using Microsoft.AspNetCore.Identity;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TaskContext _context;
        readonly UserManager<User> _userManager;

        public TodoController(TaskContext context, UserManager<User> userManage)
        {
            _context = context;
            _userManager = userManage;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetTodoItems()
        {
            User user = await _userManager.FindByNameAsync(User.Identity.Name);
            List<ToDoItem> todo = await _context.toDoItems.Where(c => c.User == user).ToListAsync();
            return todo;
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetTodoItem(long id)
        {
            var todoItem = await _context.toDoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        [HttpPost]
        public async Task<ActionResult<ToDoItem>> PostTodoItem(ToDoItem item)
        {
            item.User = await _userManager.FindByNameAsync(User.Identity.Name);
            _context.toDoItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, ToDoItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await _context.toDoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.toDoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}