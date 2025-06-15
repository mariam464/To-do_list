using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Todolist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("To-do list");
            Console.WriteLine();
            List<Task> tasks = new List<Task>();
            TaskList taskList = new TaskList(tasks);


            bool loop = true;
            while (loop)
            {
                Console.WriteLine("1. Create a task");
                Console.WriteLine("2. Remove a task");
                Console.WriteLine("3. Show tasks");
                Console.WriteLine("4. Check a task");
                Console.WriteLine("5. Edit a task");
                Console.WriteLine("6. Exit");
                Console.WriteLine();           
                Console.Write("Enter command number: ");
                int.TryParse(Console.ReadLine(), out int command);
                switch (command)
                {
                    case 1:
                        Console.Write("Enter the task name: ");
                        string name = Console.ReadLine();

                        while (string.IsNullOrEmpty(name))
                        {
                            Console.Write("Enter a valid task name: ");
                            name = Console.ReadLine();
                        }

                        bool flag = true;

                        while (flag)
                        {
                            Console.Write("Enter deadline(yyyy-mm-dd): ");
                            string input = Console.ReadLine();
                            bool success = DateTime.TryParse(input, out DateTime deadline);
                            if (success)
                            {
                                Task task = new Task(name, deadline);
                                taskList.createTask(task);
                                flag = false;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a correct date format: (yyyy-mm-dd)");
                            }
                        }
                        break;
                    case 2:
                        Console.Write("Enter the task name: ");
                        string taskName = Console.ReadLine();
                        taskList.deleteTask(taskName);
                        break;
                    case 3:
                        taskList.showTasks();
                        break;
                    case 4:
                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("There isn't any tasks");
                            break;
                        }
                        else {
                            Console.Write("Enter task name: ");
                            taskList.checkTask(Console.ReadLine());
                        }
                        break;
                    case 5:
                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("There isn't any tasks");
                            break;
                        }
                        else { 
                        Console.Write("Enter task name: ");
                        taskList.editTask(Console.ReadLine());
                         }
                        break;
                    case 6:
                        loop = false;
                        Console.WriteLine("Good bye!");
                        break;
                    default:
                        Console.WriteLine("Invaild command");
                        break;
                }
            }
        }
    }
}
