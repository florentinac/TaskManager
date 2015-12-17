using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskManager;

namespace TaskManagerMain
{
    class TaskManagerMain
    {
        static void Main(string[] args)
        {
            string invokedVerb = null;
            object invokedVerbInstance = null;

            var options = new Options();
            TaskManager.TaskManager taskManager = new TaskManager.TaskManager();

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
                    var addSubOptions = (AddSubOptions)invokedVerbInstance;
                    taskManager.Add(addSubOptions.AddMessage, addSubOptions.AddDescription, addSubOptions.AddDate, addSubOptions.AddDuDate, addSubOptions.GetFile);
                    return;
                }

                if (invokedVerb == "update")
                {
                    var updateSubOptions = (UpdateSubOptions)invokedVerbInstance;
                    if (updateSubOptions.UpdateDate == null)
                        taskManager.UpdateStatus(updateSubOptions.GetId, updateSubOptions.GetStatus, updateSubOptions.GetFileName);
                    else taskManager.UpdateDate(updateSubOptions.GetId, updateSubOptions.UpdateDate, updateSubOptions.GetFileName);
                    Console.Write("Update finished successfully");
                    return;
                }

                if (invokedVerb == "get")
                {
                    var getSubOptions = (GetSubOptions)invokedVerbInstance;
                    if (getSubOptions.GetAscedingType == null && getSubOptions.GetDescendingType == null)
                        taskManager.GetTask(getSubOptions.GetFile);
                    else if (getSubOptions.GetAscedingType == null)
                        taskManager.SortDescending(getSubOptions.GetFile, getSubOptions.GetDescendingType);
                    else
                    {
                        taskManager.SortAscending(getSubOptions.GetFile, getSubOptions.GetAscedingType);
                    }
                    return;
                }
                if (invokedVerb == "search")
                {
                    var searchSubOptions = (SearchSubOptions)invokedVerbInstance;
                    taskManager.Search(searchSubOptions.GetWord, searchSubOptions.GetFile);
                }
            }
        }
    }
}
