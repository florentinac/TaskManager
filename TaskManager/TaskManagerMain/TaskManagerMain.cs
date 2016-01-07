namespace TaskManagerMain
{
    using System;

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
                switch (invokedVerb)
                {
                    case "add":
                        var addSubOptions = (AddSubOptions)invokedVerbInstance;
                        taskManager.Add(addSubOptions.AddMessage, addSubOptions.AddDescription, addSubOptions.AddDate, addSubOptions.AddDueDate, addSubOptions.GetFile, addSubOptions.GetTaskCategory);
                        return;
                    case "update":
                        var updateSubOptions = (UpdateSubOptions)invokedVerbInstance;
                        if (updateSubOptions.UpdateDate == null)
                            taskManager.UpdateStatus(updateSubOptions.GetId, updateSubOptions.GetStatus, updateSubOptions.GetFileName);
                        else taskManager.UpdateDate(updateSubOptions.GetId, updateSubOptions.UpdateDate, updateSubOptions.GetFileName);
                        Console.Write("Update finished successfully");
                        return;
                    case "get":
                        var getSubOptions = (GetSubOptions) invokedVerbInstance;
                        if (getSubOptions.GetAscedingType == null && getSubOptions.GetDescendingType == null && getSubOptions.GetCategoryType==null)
                            taskManager.GetTask(getSubOptions.GetFile);
                        else if (getSubOptions.GetDescendingType != null)
                            taskManager.SortDescending(getSubOptions.GetFile, getSubOptions.GetDescendingType);
                        else if (getSubOptions.GetAscedingType !=null)
                            taskManager.SortAscending(getSubOptions.GetFile, getSubOptions.GetAscedingType);
                        else taskManager.GetTaskByCategory(getSubOptions.GetFile,getSubOptions.GetCategoryType);
                        return;
                    case "search":
                        var searchSubOptions = (SearchSubOptions)invokedVerbInstance;
                        taskManager.Search(searchSubOptions.GetWord, searchSubOptions.GetFile);
                        break;
                }
            }
        }
    }
}
