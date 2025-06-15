using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todolist
{
    public class TaskList
    {
        List<Task> Tasks = new List<Task>();
        public TaskList(List<Task> tasks)
        {
            Tasks = tasks;
        }


        public void createTask(Task task)
        {
            Console.WriteLine("Wanna make it prority? (yes or No)");
            string answer = Console.ReadLine();
            answer = answer.ToLower();
            bool flag = false;
            while (!flag)
            {
                if (answer == "yes")
                {
                    task.priority = true;
                    Tasks.Add(task);
                    Console.WriteLine($"Task: {task.name}\nDeadline: {task.deadline}\nPriority:  {task.priority}");
                    flag = true;
                }
                else if (answer == "no")
                {
                    task.priority = false;
                    Tasks.Add(task);
                    Console.WriteLine($"Task: {task.name}\nDeadline: {task.deadline}\nPriority:  {task.priority}");
                    flag = true;
                }
                else
                {
                    Console.WriteLine("Please answer with yes or no");
                    answer = Console.ReadLine().ToLower();

                }
                
            }
        }

        public void showTasks()
        {
            if (Tasks.Count > 0)
            {
                foreach (var item in Tasks)
                {
                    Console.WriteLine($"Task: {item.name}\nDeadline: {item.deadline}");
                }
            }
            else
            {
                Console.WriteLine("There is no tasks.");
            }
        }
        public void deleteTask(string name)
        {
            bool found = false;
            foreach (var item in Tasks)
            {

                if (item.name == name)
                {
                    Tasks.Remove(item);
                    Console.WriteLine("Task is deleted successfully");
                    found = true;
                    break;
                }

            }
            if (found == false)
            {
                Console.WriteLine("Task doesn't exist.");
            }


        }
        public void checkTask(string name)
        {
            bool found = false;
            // Use a for loop to safely remove items while iterating
            for (int i = 0; i < Tasks.Count; i++)
            {
                if (Tasks[i].name == name)
                {
                    Tasks[i].markAsDone = true;
                    Console.WriteLine("Task is checked successfully");
                    Tasks.RemoveAt(i);
                    found = true;
                    break; // Exit after removing to avoid index issues
                }
            }
            if (!found)
            {
                Console.WriteLine("Task doesn't exist.");
            }
        }
        public void editTask(string name)
        {

            foreach (var item in Tasks)
            {
                if (item.name == name)
                {
                   bool exit = false;
                    while (!exit) {
                        Console.WriteLine("What do you want to edit?(Enter the command number)\n1.Deadline\n2.Priority\n3.Task name");
                       int.TryParse(Console.ReadLine(), out int command);
                        switch (command)
                        {
                            case 1:

                                bool flag2 = true;

                                while (flag2)
                                {
                                    Console.Write("Enter deadline: ");
                                    string input = Console.ReadLine();
                                    bool success = DateTime.TryParse(input, out DateTime deadline);
                                    if (success)
                                    {
                                        item.deadline = deadline;
                                        Console.WriteLine($"Deadline is edited successfully\nTask: {item.name}\nDeadline: {item.deadline}\nPriority: {item.priority}");
                                        flag2 = false; // Exit the loop if the date is valid
                                        exit = true; // Exit the loop after editing deadline
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter a correct date format: (yyyy-mm-dd)");
                                    }
                               
                                }
                                break;
                            case 2:
                                item.priority = !item.priority;
                                Console.WriteLine($"Priority is changed successfully \\nTask: {item.name}\\nDeadline: {item.deadline}\\nPriority: {item.priority}");
                                
                                exit = true;
                                break;
                            case 3:
                                Console.Write("Enter new name: ");
                                item.name = Console.ReadLine();
                                Console.WriteLine($"Task name is changed successfully\nTask: {item.name}\nDeadline: {item.deadline}\nPriority: {item.priority}");
                                exit = true;
                                break;
                            default:
                                Console.WriteLine("Invaid command");
                                break;
                        }
                    }
                }
                else {  
                             Console.WriteLine("Task doesn't exist."); 
                }
            }
            
        }
    }
}
