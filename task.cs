using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todolist
{
    public class Task 
    {
        public string name { get; set; }
        public DateTime deadline { get; set; }
        public bool priority { get; set; } 
        public bool markAsDone { get; set; }



        public Task(string name, DateTime deadline)
        {
            this.name = name;
            this.deadline = deadline;
            this.priority = false;
            this.markAsDone = false;
        }
       
    }
}





