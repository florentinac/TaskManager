using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Parsing;
using CommandLine.Text;

namespace TaskManager
{
    public class AddSubOptions
    {       
        [Option('m', "message", Required = true, HelpText = "Specifiy the task to be added")]
        public string AddMessage { get; set; }

        [Option('d', "date", HelpText = "Specifiy or not the date for task, the format for date is: dd-MM-yyyy")]
        public string AddDate { get; set; }

        [Option('f', "fileName", HelpText = "Specifiy or not the file for save the Tasks")]
        public string GetFile { get; set; }

    }

    public class UpdateSubOptions
    {

        [Option("id", Required = true,HelpText = "Specifiy the task id")]
        public string GetId { get; set; }

        [Option('d', "date", HelpText = "Update status from ToDo to Done")]
        public string UpdateDate { get; set; }

        [Option('s',"status", HelpText = "Change Due Date, format for date dd - MM - yyyy")]
        public string GetStatus { get; set; }

        [Option('f', "fileName", HelpText = "Specify the fileName where are the Tasks")]
        public string GetFileName { get; set; }
    }

    public class GetSubOptions
    {
        [Option('f', "fileName", HelpText = "Specify the fileName where are the Tasks")]
        public string GetFile { get; set; }
    }

    public class SortSubOptions
    {
        [Option('a', "asscending", HelpText = "Sort Ascending the Tasks by Date")]
        public string GetAsscending { get; set; }

        [Option('d', "descending", HelpText = "Sort Descending the Tasks by Date")]
        public string GetDescending { get; set; }

    }

    public class SearchSubOptions
    {
        [Option('f', "fileName", HelpText = "Specify the fileName where are the Tasks")]      
        public string GetFile { get; set; }
        [Option('w', "word",Required = true, HelpText = "Specify the word for search")]
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

        [VerbOption("sort", HelpText = "Sort the Tasks.")]
        public SortSubOptions GetSortParameters { get; set; }

        [VerbOption("search", HelpText = "Search a word in Tasks.")]
        public SearchSubOptions  GetSearchParameters{ get; set; }

        [HelpVerbOption]
        public string GetUsage(string verb)
        {
            return HelpText.AutoBuild(this, verb);
        }
    }

}
