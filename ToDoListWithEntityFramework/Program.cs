using Microsoft.IdentityModel.Tokens;
using ToDoListWithEntityFramework.Data;
using ToDoListWithEntityFramework.Models;

namespace ToDoListWithEntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DateTime dt = DateTime.Today;

            Console.WriteLine(DateOnly.FromDateTime(dt));

			Console.Write("Welcome to the To-Do List App\nEnter your name: ");
            
            User user = new User(Console.ReadLine());

            while (true)
            {
                Console.WriteLine($"\n{new string('-', 40)}");

                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add a task to your to-do list");
                Console.WriteLine("2. Update a task in your to-do list");
                Console.WriteLine("3. Mark task as completed");
                Console.WriteLine("4. Unmark task as completed");
                Console.WriteLine("5. Delete task from your to-do list");
                Console.WriteLine("6. View your to-do list");
                Console.WriteLine("7. View task(s) on a specific date");
                Console.WriteLine("0. Exit the app");

                Console.Write("\nEnter option number: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddTask(user);
                            Console.ReadKey();
                            break;

                        case 2:
                            user.ViewToDoList();
                            UpdateTask(user);
                            Console.ReadKey();
                            break;

                        case 3:
                            user.ViewToDoList();
                            MarkCompleted(user);
                            Console.ReadKey();
                            break;

                        case 4:
                            user.ViewToDoList();
                            UnmarkCompleted(user);
                            Console.ReadKey();
                            break;

                        case 5:
                            user.ViewToDoList();
                            DeleteTask(user);
                            Console.ReadKey();
                            break;

                        case 6:
                            user.ViewToDoList();
                            Console.ReadKey();
                            break;

                        case 7:
                            ViewListOn(user);
                            Console.ReadKey();
                            break;

                        case 0:
                            Console.WriteLine($"\n*** Exiting the application. Goodbye {user.Name}! ***");
                            return;

                        default:
                            Console.WriteLine("Invalid choice! Number must be between 1-7 or 0");
                            Console.ReadKey();
                            break;
                    }
                }
                else 
                { 
                    Console.WriteLine("Invalid choice! Input must be a number between 1-7 or 0");
                    Console.ReadKey();
                }
            }
        }
        

        private static void AddTask(User user)
        {

            Console.Write("\nEnter task title: ");
            string title = Console.ReadLine();
            if (title.IsNullOrEmpty())
            {
                Console.WriteLine("Task title cannot be empty/null");
                AddTask(user);
            }
            DateTime date;
            GetDate(out date);

            user.AddTaskItem(title, date);
            Console.WriteLine("Task added successfully!");
        }

        private static void UpdateTask(User user)
        {
            Console.WriteLine("\nEnter Id of task to be updated");

            int Id;
            GetId(user, out Id);

            Console.WriteLine("\nI want to update: ");
            Console.WriteLine("1. Title only");
            Console.WriteLine("2. Date only");
            Console.WriteLine("3. Both");

            Console.Write("\nEnter option number: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("New title: ");
                        user.UpdateTaskItem(Id, Console.ReadLine());
                        Console.WriteLine("Task updated successfully!");
                        break;

                    case 2:
                        DateTime date;
                        GetDate(out date);
                        user.UpdateTaskItem(Id, date);
                        Console.WriteLine("Task updated successfully!");
                        break;

                    case 3:
                        Console.Write("New title: ");
                        string newTitle = Console.ReadLine();

                        GetDate(out date);

                        user.UpdateTaskItem(Id, newTitle, date);
                        Console.WriteLine("Task updated successfully!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Number must be between 1-3");
                        Console.ReadKey();
                        UpdateTask(user);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice! Input must be a number between 1-3");
                Console.ReadKey();
                UpdateTask(user);
            }
        }

        private static void MarkCompleted(User user)
        {
            Console.WriteLine("\nEnter Id to be marked as completed");

            int Id;
            GetId(user, out Id);

            user.MarkTaskAsCompleted(Id);
            Console.WriteLine("Task successfully marked as completed!");
        }

        private static void UnmarkCompleted(User user)
        {
            Console.WriteLine("\nEnter Id to be unmarked as completed");
            int Id;
            GetId(user, out Id);

            user.UnmarkTaskAsCompleted(Id);
            Console.WriteLine("Task successfully unmarked as completed!");
        }

        private static void DeleteTask(User user)
        {
            Console.WriteLine("\nEnter Id to be deleted");
            int Id;
            GetId(user, out Id);

            user.DeleteTaskItem(Id);
            Console.WriteLine("Task deleted successfully!");
        }

        private static void ViewListOn(User user)
        {
            DateTime date;
            GetDate(out date);

            user.ViewTasksOn(date);
        }


        private static void GetDate(out DateTime date)
        {
            Console.WriteLine("\nSpecify date:");
            Console.WriteLine("1. Using days from now; eg. (-1=yesterday, 0=today, 1=tomorrow, etc)");
            Console.WriteLine("2. Enter date manually");

            Console.Write("\nEnter option number: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter an integer representing the day from now: ");
                        if (int.TryParse(Console.ReadLine(), out int dayNumber))
                        {
                            date = DateTime.Today.AddDays(dayNumber);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input! Input must be an integer");
                            Console.ReadKey();
                            GetDate(out date);
                        }
                        break;

                    case 2:
                        Console.Write("Enter year (eg. 2019): ");
                        int year = int.Parse(Console.ReadLine());
                        Console.Write("Enter month (eg. 9): ");
                        int month = int.Parse(Console.ReadLine());
                        Console.Write("Enter day (eg. 23): ");
                        int day = int.Parse(Console.ReadLine());

                        date = new DateTime(year, month, day);
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Number must be between 1-2");
                        Console.ReadKey();
                        GetDate(out date);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice! Input must be a number between 1-2");
                Console.ReadKey();
                GetDate(out date);
            }
        }

        private static void GetId(User user, out int Id)
        {
            Console.Write("\nEnter Id: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (user.context.TaskItems.FirstOrDefault(i => i.Id == id) == null)
                {
                    Console.WriteLine("Invalid Id! Id does not exist");
                    Console.ReadKey();
                    GetId(user, out Id);
                }
                else
                {
                    Id = id;
                }
            }
            else
            {
                Console.WriteLine("Invalid input! Input must be an integer");
                Console.ReadKey();
                GetId(user, out Id);
            }
        }

    }
}
