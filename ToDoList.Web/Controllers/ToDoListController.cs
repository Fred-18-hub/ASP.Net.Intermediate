using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Web.Data;
using ToDoList.Web.Models;

namespace ToDoList.Web.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly ToDoListDbContext _dbContext;

        public ToDoListController(ToDoListDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _dbContext.Tasks.ToListAsync());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        //[ActionName("Add")]
        public async Task<IActionResult> Add(TaskItem taskItem)
        {
            _dbContext.Add(taskItem);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var task = await _dbContext.Tasks.FirstOrDefaultAsync(i => i.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            var task = await _dbContext.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TaskItem taskItem)
        {
            int id = taskItem.Id;
            string title = taskItem.Title;
            DateTime date = taskItem.DateToPerform;

            return RedirectToAction(nameof(Index));
        }
    }
}
