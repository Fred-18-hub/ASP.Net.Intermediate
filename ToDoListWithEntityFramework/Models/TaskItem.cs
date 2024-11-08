using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListWithEntityFramework.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        [Column(TypeName = "date")]
        public DateTime ToBeCompleted { get; set; } = DateTime.Today;
        public bool Completed { get; set; }
    }
}
