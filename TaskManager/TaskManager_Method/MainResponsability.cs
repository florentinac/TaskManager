using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager;

namespace TaskManager
{
    public class MainResponsability
    {
        private TaskFunctionality taskManager = new TaskFunctionality();

        public void AddNewTask(string[] args)
        {
            if (args[0].Equals("add"))
            {
                var date = DateTime.Now;
                var fileName = "Tasks.txt";
                if (args.Length <= 1)
                {
                    Console.WriteLine(" --message: Specifiy the task to be added" +
                                  "\r\n --date: Specifiy or not the date for task, the format for date is: dd-MM-yyyy"+
                                  "\r\n --fileName: Specifiy or not the file for save the Tasks");
                }
                else
                {
                    if (args.Length > 3 && args[3].Equals("--date"))
                    {
                        if (args.Length == 7)
                            fileName = args[6];
                        date = DateTime.ParseExact(args[4], "dd-MM-yyyy",
                                System.Globalization.CultureInfo.InvariantCulture);
                        taskManager.Add(args[2], date, fileName);
                        Console.WriteLine("The task " + taskManager.Count + " was successfuly added");
                        return;
                    }
                    if (args.Length > 3 && args[3].Equals("--filename"))
                        fileName = args[4];
                    taskManager.Add(args[2], date, fileName);
                    Console.WriteLine("The task " + taskManager.Count + " was successfuly added");
                }
            }
        }

        public void UpdateTask(string[] args)
        {
            if (args[0].Equals("update"))
            {
                if (args.Length > 1)
                {
                    if(args[3].Equals("--status"))
                        taskManager.UpdateStatus(args[2]);
                    if(args[3].Equals("--date"))
                        taskManager.UpdateDate(args[2], args[4]);
                    Console.WriteLine("Update finished successfully!");
                }
                else
                {
                    Console.WriteLine("--id: Specifiy the task id");
                }
            }
        }

        public void GetTask(string[] args)
        {
            if (args[0].Equals("get"))
            {
                if (args.Length == 1)
                {
                    var lines = taskManager.GetTask("Tasks.txt");
                    WriteTask(lines);
                }              
                else
                {
                    if (args.Length < 3)
                    {
                        Console.WriteLine("Specify the fileName where are the Tasks");
                        return;
                    }
                    var lines = taskManager.GetTask(args[2]);
                    WriteTask(lines);
                }
            }
        }

        private void WriteTask(string[] lines)
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
