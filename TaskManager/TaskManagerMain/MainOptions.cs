namespace TaskManagerMain
{
    using CommandLine;
    using CommandLine.Text;

    public class AddSubOptions
    {
        [Option('m', "message", Required = true, HelpText = "Specifiy the task to be added")]
        public string AddMessage { get; set; }

        [Option('d', "date", HelpText = "Specifiy or not the date for task, the format for date is: MM-dd-yyyy")]
        public string AddDate { get; set; }

        [Option('f', "fileName", HelpText = "Specifiy or not the file for save the Tasks")]
        public string GetFile { get; set; }

        [Option("description", HelpText = "Specifiy the description of task")]
        public string AddDescription { get; set; }

        [Option("dueDate", HelpText = "Specifiy the du date for task, the format for date is: MM-dd-YYYY hh:mm:ss.ff ")]
        public string AddDueDate { get; set; }

        [Option('c', "category", Required = true, HelpText = "Specifiy the task category")]
        public string GetTaskCategory { get; set; }
    }

    public class UpdateSubOptions
    {

        [Option("id", Required = true, HelpText = "Specifiy the task id")]
        public string GetId { get; set; }

        [Option('d', "date", HelpText = "Change Due Date, format for date MM-dd-yyyy")]
        public string UpdateDate { get; set; }

        [Option('s', "status", HelpText = "Update status from ToDo to Done")]
        public string GetStatus { get; set; }

        [Option('f', "fileName", HelpText = "Specify the fileName where are the Tasks")]
        public string GetFileName { get; set; }
    }

    public class GetSubOptions
    {
        [Option('f', "fileName", HelpText = "Specify the fileName where are the Tasks")]
        public string GetFile { get; set; }

        [Option('a', "asc", HelpText = "Specify sorting criteria (date, title, id)")]
        public string GetAscedingType { get; set; }

        [Option('d', "desc", HelpText = "Specify sorting criteria (date, title, id)")]
        public string GetDescendingType { get; set; }

        [Option('c', "category", HelpText = "Specify the tasks category")]
        public string GetCategoryType { get; set; }
    }

    public class SearchSubOptions
    {
        [Option('f', "fileName", HelpText = "Specify the fileName where are the Tasks")]
        public string GetFile { get; set; }
        [Option('w', "word", Required = true, HelpText = "Specify the word for search")]
        public string GetWord { get; set; }
    }

    public class Options
    {

        [VerbOption("add", HelpText = "Add new task and save in a file.")]
        public AddSubOptions GetAddParameters { get; set; }

        [VerbOption("update", HelpText = "Update the Task with new status or date.")]
        public UpdateSubOptions GetUpdateParameters { get; set; }

        [VerbOption("get", HelpText = "Get the existents Tasks.")]
        public GetSubOptions GetParameters { get; set; }

        [VerbOption("search", HelpText = "Search a word in Tasks.")]
        public SearchSubOptions GetSearchParameters { get; set; }

        [HelpVerbOption]
        public string GetUsage(string verb)
        {
            return HelpText.AutoBuild(this, verb);
        }
    }
}
