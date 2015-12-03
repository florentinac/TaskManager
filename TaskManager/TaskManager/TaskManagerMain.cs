using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager;
using Task = TaskManager.Task;

namespace TaskManager
{
    class TaskManagerMain
    {
        static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                Console.Write("The syntax of this product is:" +
                              "\r\nADD: Add new task and save in a file" +
                              "\r\n     --message:  Specifiy the task to be added" +
                              "\r\n     --date: Specifiy the date for task" +
                              "\r\nGET: Get the existents Tasks" +
                              "\r\n     --fileName: Specify the fileName where is the Tasks" +
                              "\r\nUPDATE: Update the Task with new status"+
                              "\r\n     --id: Specifiy the task id");
                Console.WriteLine(" ");
            }
            else
            {
                var taskManager = new TaskFunctionality();
                GetTask(args, taskManager);
                UpdateTask(args, taskManager);

                AddNewTask(args, taskManager);
            }
        }

        private static void AddNewTask(string[] args, TaskFunctionality taskManager)
        {
            if (args[0].Equals("add"))
            {
                var date = DateTime.Now;
                if (args.Length <= 1)
                {
                    Console.WriteLine(" --message: Specifiy the task to be added" +
                                  "\r\n --date: Specifiy or not the date for task");
                }
                else
                {
                    for (var i = 2; i < args.Length; i++)
                    {
                        if (i < args.Length-1 && args[i+1].Equals("date"))
                        {
                            date = DateTime.ParseExact(args[i+2], "dd-MM-yyyy",
                                System.Globalization.CultureInfo.InvariantCulture);
                            taskManager.Add(args[i], date);
                            Console.WriteLine("The task " + taskManager.Count + " was successfuly added");
                            return;
                        }
                        taskManager.Add(args[i], date);
                        Console.WriteLine("The task " + taskManager.Count + " was successfuly added");                       
                    }
                }
            }
        }

        private static void UpdateTask(string[] args, TaskFunctionality taskManager)
        {
            if (args[0].Equals("update"))
            {
                if (args.Length > 1)
                {                  
                    taskManager.Update(args[1]);
                    Console.WriteLine("Update finished successfully!");
                }
                else
                {
                    Console.WriteLine("--id: Specifiy the task id");
                }
            }
        }

        private static void GetTask(string[] args, TaskFunctionality taskManager)
        {
            if (args[0].Equals("get"))
            {
                if (args.Length < 3)
                    Console.Write("--fileName: Specifiy the file Name");
                else
                {
                    var lines = taskManager.GetTask(args[2]);

                    WriteTask(lines);
                }
            }
        }

        private static void WriteTask(string[] lines)
        {
            if (lines != null)
                foreach (var line in lines)
                {
                    Console.WriteLine("\t" + line);
                }
            else
            {
                Console.WriteLine("Does not exists tasks. First you must add some new tasks");
            }
        }
    }
}
