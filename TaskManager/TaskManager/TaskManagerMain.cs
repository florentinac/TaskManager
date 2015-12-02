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
            if (args.Length > 0)
            {
                var taskManager = new TaskManager<Task>();
                if (args[0].Equals("get"))
                {
                    var lines=taskManager.GetTask();
                    foreach (var line in lines)
                    {
                        Console.WriteLine("\t" + line);
                    }
                }

                else
                {
                    for (var i = 1; i < args.Length - 1; i++)
                    {
                        var task = new Task(args[i + 1], DateTime.Now, Status.ToDo);

                        taskManager.Add(task);
                        Console.WriteLine("The task " + taskManager.Count + " was successfuly added");
                        var taskFile = task.GetName + " " + task.GetDate + " " + task.GetStatus;
                        Console.WriteLine(taskFile);
                        taskManager.SaveTask(taskFile);
                    }
                }
            }
            else
            {
                Console.Write("The sitax of this product is:" +
                              "\r\nADD:" +
                              "\r\n     --message:  Specifiy the task to be added" +
                              "\r\nGet: Get the existents Tasks");
                Console.WriteLine(" ");
            }

        }
    }
}
