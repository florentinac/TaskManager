using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public class TaskView: Repository
    {
        public TaskView(string filename):base(filename)
        {

        }

        public void SortAsc(string orderBy)
        {
            switch (orderBy)
            {
                case "date":
                    SortDateAscending();
                    break;
                case "id":
                    GetTasks();
                    break;
                case "title":
                    SortTaskByNameAsc();
                    break;
            }
        }

        public void SortDesc(string orderBy)
        {
            switch (orderBy)
            {
                case "date":
                    SortDateDesc();
                    break;
                case "id":
                    SortTaskByIdDesc();
                    break;
                case "title":
                    SortTaskByNameDesc();
                    break;
            }
        }

        private void SortDateDesc()
        {
            var sortedTasks = from task in
                xml.Descendants(GlobalConstants.Task).OrderByDescending(p => DateTime.Parse(p.Element("Date").Value))
                              select new
                              {
                                  Id = task.Element(GlobalConstants.Id).Value,
                                  Name = task.Element(GlobalConstants.Title).Value,
                                  Description = task.Element(GlobalConstants.Descr).Value,
                                  Date = task.Element(GlobalConstants.Date).Value,
                                  DuDate = task.Element(GlobalConstants.DuDate).Value,
                                  Status = task.Element(GlobalConstants.Status).Value
                              };
            foreach (var sortedTask in sortedTasks)
            {
                Console.WriteLine(sortedTask.Id + " " + sortedTask.Name + " " + sortedTask.Description + " " +
                                 sortedTask.Date + " " + sortedTask.DuDate + " " + sortedTask.Status);
            }
        }

        private void SortDateAscending()
        {
            var sortedTasks = from task in
                xml.Descendants(GlobalConstants.Task).OrderBy(p => DateTime.Parse(p.Element("Date").Value))
                              select new
                              {
                                  Id = task.Element(GlobalConstants.Id).Value,
                                  Name = task.Element(GlobalConstants.Title).Value,
                                  Description = task.Element(GlobalConstants.Descr).Value,
                                  Date = task.Element(GlobalConstants.Date).Value,
                                  DuDate = task.Element(GlobalConstants.DuDate).Value,
                                  Status = task.Element(GlobalConstants.Status).Value
                              };
            foreach (var sortedTask in sortedTasks)
            {
                Console.WriteLine(sortedTask.Id + " " + sortedTask.Name + " " + sortedTask.Description + " " +
                                  sortedTask.Date + " " + sortedTask.DuDate + " " + sortedTask.Status);
            }
        }

        private void SortTaskByIdDesc()
        {
            var sortedTasks = from task in xml.Descendants(GlobalConstants.Task).OrderByDescending(r => r.Element(GlobalConstants.Id).Value)
                              select new
                              {
                                  Id = task.Element(GlobalConstants.Id).Value,
                                  Name = task.Element(GlobalConstants.Title).Value,
                                  Description = task.Element(GlobalConstants.Descr).Value,
                                  Date = task.Element(GlobalConstants.Date).Value,
                                  DuDate = task.Element(GlobalConstants.DuDate).Value,
                                  Status = task.Element(GlobalConstants.Status).Value
                              };
            foreach (var sortedTask in sortedTasks)
            {
                Console.WriteLine(sortedTask.Id + " " + sortedTask.Name + " " + sortedTask.Description + " " +
                                  sortedTask.Date + " " + sortedTask.DuDate + " " + sortedTask.Status);
            }
        }

        private void SortTaskByNameDesc()
        {
            var sortedTasks = from task in xml.Descendants(GlobalConstants.Task).OrderByDescending(r => r.Element(GlobalConstants.Title).Value)
                              select new
                              {
                                  Id = task.Element(GlobalConstants.Id).Value,
                                  Name = task.Element(GlobalConstants.Title).Value,
                                  Description = task.Element(GlobalConstants.Descr).Value,
                                  Date = task.Element(GlobalConstants.Date).Value,
                                  DuDate = task.Element(GlobalConstants.DuDate).Value,
                                  Status = task.Element(GlobalConstants.Status).Value
                              };
            foreach (var sortedTask in sortedTasks)
            {
                Console.WriteLine(sortedTask.Id + " " + sortedTask.Name + " " + sortedTask.Description + " " +
                                  sortedTask.Date + " " + sortedTask.DuDate + " " + sortedTask.Status);
            }
        }

        private void SortTaskByNameAsc()
        {
            var sortedTasks = from task in xml.Descendants(GlobalConstants.Task).OrderBy(r => r.Element(GlobalConstants.Title).Value)
                              select new
                              {
                                  Id = task.Element(GlobalConstants.Id).Value,
                                  Name = task.Element(GlobalConstants.Title).Value,
                                  Description = task.Element(GlobalConstants.Descr).Value,
                                  Date = task.Element(GlobalConstants.Date).Value,
                                  DuDate = task.Element(GlobalConstants.DuDate).Value,
                                  Status = task.Element(GlobalConstants.Status).Value
                              };
            foreach (var sortedTask in sortedTasks)
            {
                Console.WriteLine(sortedTask.Id + " " + sortedTask.Name + " " + sortedTask.Description + " " +
                                  sortedTask.Date + " " + sortedTask.DuDate + " " + sortedTask.Status);
            }

        }
        public void ViewTaskMatch(string word)
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
                Console.WriteLine(" " + task.Element(GlobalConstants.Descr).Value + " " + task.Element(GlobalConstants.Date).Value + " " +
                              task.Element(GlobalConstants.DuDate).Value + " " + task.Element(GlobalConstants.Status).Value + " ");
            }
        }

        //private void DisplayHTML(string input)
        //{
        //    var xslt = new XslCompiledTransform(true);
        //    xslt.Load("testhtml.xsl", XsltSettings.TrustedXslt, new XmlUrlResolver());
        //    xslt.Transform(input, "test.html");
        //}
    }
}
