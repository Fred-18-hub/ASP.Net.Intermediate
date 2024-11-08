using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListWithEntityFramework.Data;
using ToDoListWithEntityFramework.Models;

namespace ToDoListWithEntityFramework
{
    public class User
    {
        public string Name { get; set; }

        public ToDoListContext context { get; } = new ToDoListContext();

        public User(string nmae)
        {
            Name = nmae;
        }

        public void AddTaskItem(TaskItem taskItem)
        {
            using ToDoListContext context = new ToDoListContext();

            context.TaskItems.Add(taskItem);
            
            context.SaveChanges();
        }

        public void AddTaskItem(string taskTitle)
        {
            using ToDoListContext context = new ToDoListContext();

            TaskItem taskItem = new TaskItem() { Title =  taskTitle };

            context.TaskItems.Add(taskItem);

            context.SaveChanges();
        }

        public void AddTaskItem(string taskTitle, DateTime taskDate)
        {
            using ToDoListContext context = new ToDoListContext();

            TaskItem taskItem = new TaskItem() { 
                Title = taskTitle,
                ToBeCompleted = taskDate
            };

            context.TaskItems.Add(taskItem);

            context.SaveChanges();
        }

        public void UpdateTaskItem(int IdToUpdate, string newTitle)
        {
            using ToDoListContext context = new ToDoListContext();
            
            var task = context.TaskItems.FirstOrDefault(t => t.Id == IdToUpdate);

            if (task != null)
            {
                task.Title = newTitle;
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Task Id {IdToUpdate} does not exist");
            }
        }

        public void UpdateTaskItem(int IdToUpdate, DateTime newDate)
        {
            using ToDoListContext context = new ToDoListContext();

            var task = context.TaskItems.FirstOrDefault(t => t.Id == IdToUpdate);

            if (task != null)
            {
                task.ToBeCompleted = newDate;
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Task Id {IdToUpdate} does not exist");
            }
        }

        public void UpdateTaskItem(int IdToUpdate, string newTitle, DateTime newDate)
        {
            using ToDoListContext context = new ToDoListContext();

            var task = context.TaskItems.FirstOrDefault(t => t.Id == IdToUpdate);

            if (task != null)
            {
                task.Title = newTitle;
                task.ToBeCompleted = newDate;
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Task Id {IdToUpdate} does not exist");
            }
        }

        public void ViewToDoList()
        {
            using ToDoListContext context = new ToDoListContext();

            var allTask = context.TaskItems.ToList();

            if (allTask.Any())
            {
                Console.WriteLine("\n### MY TO-DO LIST ###\n");
                Console.WriteLine($"Task Id{new string(' ', 7)}Task Title{new string(' ', 21)}To Be Completed{new string(' ', 15)}Status");
                Console.WriteLine($"-------{new string(' ', 7)}----------{new string(' ', 21)}---------------{new string(' ', 15)}------");
                foreach (var task in allTask)
                {
                    if (task.Completed == true)
                    {
                        Console.WriteLine($"{task.Id}{new string(' ', 13)}{task.Title}{new string(' ', 21)}{task.ToBeCompleted.ToString("dd/MM/yyyy")}{new string(' ', 15)}Completed");
                    }
                    else
                    {
                        Console.WriteLine($"{task.Id}{new string(' ', 13)}{task.Title}{new string(' ', 21)}{task.ToBeCompleted.ToString("dd/MM/yyyy")}{new string(' ', 15)}Not completed");
                    }
                }
            }
            else { Console.WriteLine("Your to-do list is empty");  }
        }

        public void ViewTasksOn(DateTime date)
        {
            using ToDoListContext context = new ToDoListContext();

            var allTask = context.TaskItems.Where(d => d.ToBeCompleted == date);

            if (allTask.Any())
            {
                Console.WriteLine($"\nMY TASKS ON {date.ToString("dd/MM/yyyy")}");
                foreach (var task in allTask)
                {
                    Console.WriteLine($"{task.Id}{new string(' ', 13)}{task.Title}");
                }
            }
            else
            {
                Console.WriteLine($"\nYou have no tasks on {date.ToString("dd/MM/yyyy")}");
            }
        }

        public void MarkTaskAsCompleted(int IdToMarkAsCompleted)
        {
            using ToDoListContext context = new ToDoListContext();

            var taskToMarkAsCompleted = context.TaskItems.FirstOrDefault(i => i.Id == IdToMarkAsCompleted);

            if (taskToMarkAsCompleted != null)
            {
                taskToMarkAsCompleted.Completed = true;
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Task Id {IdToMarkAsCompleted} does not exist");
            }
        }

        public void MarkTaskAsCompleted(int[] IdsToMarkAsCompleted)
        {
            using ToDoListContext context = new ToDoListContext();

            var tasksToMarkAsCompleted = context.TaskItems.Where(i => IdsToMarkAsCompleted.Contains(i.Id));

            if (tasksToMarkAsCompleted.Any())
            {
                foreach (var task in tasksToMarkAsCompleted)
                {
                    task.Completed = true;
                }
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("None of the Ids provided exists");
            }
        }

        public void UnmarkTaskAsCompleted(int IdToUnmarkAsCompleted)
        {
            using ToDoListContext context = new ToDoListContext();

            var taskToUnmarkAsCompleted = context.TaskItems.FirstOrDefault(i => i.Id == IdToUnmarkAsCompleted);

            if (taskToUnmarkAsCompleted != null)
            {
                taskToUnmarkAsCompleted.Completed = false;
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Task Id {IdToUnmarkAsCompleted} does not exist");
            }
        }

        public void UnmarkTaskAsCompleted(int[] IdsToUnmarkAsCompleted)
        {
            using ToDoListContext context = new ToDoListContext();

            var tasksToUnmarkAsCompleted = context.TaskItems.Where(i => IdsToUnmarkAsCompleted.Contains(i.Id));

            if (tasksToUnmarkAsCompleted.Any())
            {
                foreach ( var task in tasksToUnmarkAsCompleted)
                {
                    task.Completed = false;
                }
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("None of the Ids provided exists");
            }
        }

        public void DeleteTaskItem(int idToDelete)
        {
            using ToDoListContext context = new ToDoListContext();

            var taskToDelete = context.TaskItems.FirstOrDefault(i => i.Id ==  idToDelete);

            if (taskToDelete != null)
            {
                context.TaskItems.Remove(taskToDelete);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Task Id {idToDelete} does not exist");
            }
        }

        public void DeleteTaskItem(int[] idsToDelete)
        {
            using ToDoListContext context = new ToDoListContext();

            var tasksToDelete = context.TaskItems.Where(i => idsToDelete.Contains(i.Id));

            if (tasksToDelete.Any())
            {
                foreach (var task in tasksToDelete)
                {
                    context.TaskItems.Remove(task);
                }
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("None of the Ids provided exists");
            }
        }


    }
}
