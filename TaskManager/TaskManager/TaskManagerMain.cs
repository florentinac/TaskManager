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
            var task = new Task(args[0],DateTime.Today, Status.ToDo);
            var secondTask = new Task(args[1], DateTime.Today, Status.InProgress);
            var taskManager = new TaskManager_Methods<Task>();

            taskManager.Add(task);
            taskManager.Add(secondTask);
            for (var i = 0; i < taskManager.Count; i++)
            {
                Console.WriteLine(taskManager.Tasks[i].status+" " + taskManager.Tasks[i].taskName+" "+ taskManager.Tasks[i].date);              
            }
        }
    }
}
