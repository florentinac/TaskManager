namespace TaskManager_Method
{
    using System;
    using System.Linq;
    using TaskManager;

    public class SearchTask:CreateXMLDoc
    {
        public SearchTask(string fileName) : base(fileName)
        {
        }

        public void SearchTaskMatch(string word)
        {
            var tasksMatch = from task in xml.Descendants(GlobalConstants.Task)
                where task.Element(GlobalConstants.Descr).Value.Contains(word) || 
                task.Element(GlobalConstants.Title).Value.Contains(word)               
                select task;                    
            foreach (var task in tasksMatch)
            {
                Console.Write(task.Element(GlobalConstants.Id).Value + " ");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write(task.Element(GlobalConstants.Title).Value);  
                Console.ResetColor();                          
                Console.WriteLine(" "+task.Element(GlobalConstants.Descr).Value + " " + task.Element(GlobalConstants.Date).Value + " " +
                              task.Element(GlobalConstants.DuDate).Value + " " + task.Element(GlobalConstants.Status).Value + " ");
            }
        }
    }
}
