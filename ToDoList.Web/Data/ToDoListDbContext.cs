using Microsoft.EntityFrameworkCore;
using ToDoList.Web.Models;

namespace ToDoList.Web.Data
{
    public class ToDoListDbContext : DbContext
    {
        public ToDoListDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TaskItem> Tasks { get; set; } = default!;
    }
}
