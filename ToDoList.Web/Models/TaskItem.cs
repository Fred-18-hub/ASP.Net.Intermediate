using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Web.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }

        //[Column(TypeName = "date")]
        //[DisplayFormat(DataFormatString = "{0:u}")]     // Autommatically converts datetime from local to utc (which is acceptable by PG)

        private DateTime _dateToPerform = DateTime.Now.ToUniversalTime();
        
		public DateTime DateToPerform
        { 
            get { return _dateToPerform; }
            set 
            {   
                _dateToPerform = new DateTime(DateOnly.FromDateTime(value), TimeOnly.FromDateTime(DateTime.Now)).ToUniversalTime(); 
            }
        }
        public bool IsCompleted { get; set; }
        //public DateTime DateCompleted { get; set; }
    }
}
