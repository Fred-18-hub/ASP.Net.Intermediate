namespace ToDoListAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter username : ");
            string username = Console.ReadLine();

            User fred = new User(username);

            Console.WriteLine("\nHello {0}, welcome!\n", fred.username);
            //Console.WriteLine(fred.id);

            fred.viewToDoList();

            fred.addTask(1, "Purchase RGB strip");
            fred.addTask(2, "Take out the trash");
            fred.viewToDoList();

            fred.markTaskAsCompleted(2);
            fred.viewToDoList();

            fred.addTask(3, "Make fried rice for dinner");
            fred.viewToDoList();

            fred.addTask(4, "Call Mom");
            fred.viewToDoList();

            fred.markTaskAsCompleted([1, 3]);
            fred.viewToDoList();
            fred.viewLiveTasks();
            fred.viewCompletedTasks();

        }
    }


    public class TaskItem
    {
        public int taskID;
        public static List<int> taskIDs = [];
        public string taskName {  get; set; }
        public bool completed = false;

        public TaskItem(int taskID, string taskName)
        {
            taskIDs.Add(taskID);
            this.taskName = taskName;
            this.taskID = taskID;
        }
 
    }


    public class User
    {
        public string id { get; set; }
        public string username;
        public List<TaskItem> taskList;

        public User(string username)
        {
            Random randomInt = new Random();
            id = $"u{randomInt.Next(100, 1000)}";

            this.username = username;
            taskList = [];
        }

        public void addTask(int taskID, string taskName)
        {
            if (!TaskItem.taskIDs.Contains(taskID))
            {
                TaskItem task = new TaskItem(taskID, taskName);
                taskList.Add(task);
            }
            else
            {
                Console.WriteLine("The taskID already exists");
            }
        }

        public void markTaskAsCompleted(int id)
        {
            if (!TaskItem.taskIDs.Contains(id))
            {
                Console.WriteLine($"TaskID {id} does not exist");
            }
            else
            {
                foreach (TaskItem task in taskList)
                {
                    if (task.taskID == id)
                    {
                        task.completed = true;
                    }
                }
            }
            
        }

        public void markTaskAsCompleted(int[] ids)
        {
            foreach(int id in ids)
            {
                if(!TaskItem.taskIDs.Contains(id))
                {
                    Console.WriteLine($"TaskID {id} does not exist");
                }
                else
                {
                    foreach(TaskItem task in taskList)
                    {
                        if(task.taskID == id)
                        {
                            task.completed = true;
                        }
                    }
                }
            }
        }

        public void viewLiveTasks()
        {
            if (taskList.Any())
            {
                Console.WriteLine("\n### LIVE TASKS ###\n");
                bool liveTasksAvailable = false;

                foreach (TaskItem task in taskList)
                {
                    if (task.completed == false)
                    {
                        Console.WriteLine($"{task.taskID}. {task.taskName}");
                        liveTasksAvailable = true;
                    }
                }

                if (!liveTasksAvailable)
                {
                    Console.WriteLine("There are no Live Tasks available");
                }
                Console.WriteLine("_______________________\n");
            }
            else
            {
                Console.WriteLine("There are no tasks in your to-do list");
            }
            
        }

        public void viewCompletedTasks()
        {
            if (taskList.Any())
            {
                Console.WriteLine("\n### COMPLETED TASKS ###\n");
                bool completedTasksAvailable = false;

                foreach (TaskItem task in taskList)
                {
                    if (task.completed)
                    {
                        Console.WriteLine($"{task.taskID}. {task.taskName}");
                        completedTasksAvailable = true;
                    }
                }

                if (!completedTasksAvailable)
                {
                    Console.WriteLine("There are no Completed Tasks available");
                }
                Console.WriteLine("_______________________\n");
            }
            else
            {
                Console.WriteLine("There are no tasks in your to-do list");
            }
        }

        public void viewToDoList()
        {
            if (taskList.Any())
            {
                Console.WriteLine("\n### MY TO-DO LIST ###\n");
                foreach (TaskItem task in taskList)
                {
                    if (task.completed)
                    {
                        Console.WriteLine($"{task.taskID}. {task.taskName}\t->\tcompleted");
                    }
                    else
                    {
                        Console.WriteLine($"{task.taskID}. {task.taskName}\t->\tnot completed");
                    }
                    
                }
                Console.WriteLine("_______________________\n");
            }
            else
            {
                Console.WriteLine("There are no tasks in your to-do list");
            }
        }
    }
}