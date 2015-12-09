﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManager;

namespace TaskManager
{
    class TaskManagerMain
    {
        private static void Main(string[] args)
        {

            string invokedVerb = null;
            object invokedVerbInstance = null;

            var options = new Options();
            TaskFunctionality taskManager = new TaskFunctionality();

            if (!CommandLine.Parser.Default.ParseArguments(args, options,
                (verb, subOptions) =>
                {
                    invokedVerb = verb;
                    invokedVerbInstance = subOptions;
                }))
            {
                options.GetUsage(invokedVerb);
            }
            if (invokedVerbInstance != null)
            {
                if (invokedVerb == "add")
                {
                    var addSubOptions = (AddSubOptions) invokedVerbInstance;
                    taskManager.Add(addSubOptions.AddMessage, addSubOptions.AddDate, addSubOptions.GetFile);
                    Console.WriteLine("The task " + taskManager.Count + " was successfuly added");

                }

                if (invokedVerb == "update")
                {
                    var updateSubOptions = (UpdateSubOptions) invokedVerbInstance;
                    if(updateSubOptions.UpdateDate==null)
                        taskManager.UpdateStatus(updateSubOptions.GetId, updateSubOptions.GetStatus, updateSubOptions.GetFileName);
                    else taskManager.UpdateDate(updateSubOptions.GetId, updateSubOptions.UpdateDate, updateSubOptions.GetFileName);
                  
                }

                if (invokedVerb == "get")
                {
                    var getSubOptions = (GetSubOptions) invokedVerbInstance;

                    taskManager.GetTask(getSubOptions.GetFile);
                }

                if (invokedVerb == "sort")
                {
                   // var sortSubOptions = (SortSubOptions)invokedVerbInstance;
                    taskManager.SortAscending("Tasks.txt");
                }
            }
        }

    }
                   
}
