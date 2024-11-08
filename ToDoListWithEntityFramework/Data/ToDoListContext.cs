using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListWithEntityFramework.Models;

namespace ToDoListWithEntityFramework.Data
{
    public class ToDoListContext : DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=To-Do List Database;Integrated Security=True;");
        }
    }
}
