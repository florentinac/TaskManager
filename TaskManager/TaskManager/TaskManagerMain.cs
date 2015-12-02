﻿using System;
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
            if (args.Length > 0)
            {
                var taskManager = new TaskFunctionality();
                if (args[0].Equals("get"))
                {
                    var lines=taskManager.GetTask();
                    foreach (var line in lines)
                    {
                        Console.WriteLine("\t" + line);
                    }
                }
                if (args[0].Equals("update"))
                {
                    taskManager.Update(int.Parse(args[1]));
                }

                else
                {
                    for (var i = 1; i < args.Length - 1; i++)
                    {                      
                        taskManager.Add(args[i+1]);
                        Console.WriteLine("The task " + taskManager.Count + " was successfuly added");                       
                    }
                }
            }
            else
            {
                Console.Write("The sitax of this product is:" +
                              "\r\nADD:" +
                              "\r\n     --message:  Specifiy the task to be added" +
                              "\r\nGet: Get the existents Tasks"+
                              "\r\nUpdate: put the Task to Done");
                Console.WriteLine(" ");
            }

        }
    }
}
