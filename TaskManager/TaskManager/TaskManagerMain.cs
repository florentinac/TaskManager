using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Method;
using Task = TaskManager_Method.Task;

namespace TaskManager
{
    class TaskManagerMain
    {
        static void Main(string[] args)
        {
            var taskName2 = "Go to work";
            var taskname = "Go to school";    
            var task = new Task(taskname,DateTime.Today, Status.ToDo);
            var secondTask = new Task(taskName2, DateTime.Today, Status.ToDo);
            var taskManager = new TaskManager<Task>();

            taskManager.Add(task);
            taskManager.Add(secondTask);
            for (var i = 0; i < taskManager.Count; i++)
            {
                Console.WriteLine(taskManager);              
            }
        }
    }
}
