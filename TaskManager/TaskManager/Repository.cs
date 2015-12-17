namespace TaskManager
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Xml.Linq;

    public class Repository
    {
        private string fileName;
        protected XDocument xml;

        public Repository() { }

        public Repository(string fileName)
        {
            var path = new PathClass();
            this.fileName = path.FilePath(fileName);

            InitXMLDocument();
        }

        private void InitXMLDocument()
        {
            try
            {
                xml = XDocument.Load(fileName);
            }
            catch (Exception)
            {
                var xmlFile = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XComment("XML File for storing "));
                xmlFile.Add(new XElement(GlobalConstants.TaskM));
                xmlFile.Save(fileName);
                xml = XDocument.Load(fileName);
            }
        }

        public void GetTasks()
        {
            var tasks = from c in xml.Root.Descendants(GlobalConstants.Task)
                        select c.Element(GlobalConstants.Id).Value + " " +
                               c.Element(GlobalConstants.Title).Value + " " +
                               c.Element(GlobalConstants.Descr).Value + " " +
                               c.Element(GlobalConstants.Date).Value + " " +
                               c.Element(GlobalConstants.DueDate).Value + " " +
                               c.Element(GlobalConstants.Status).Value;
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }         
        }

        public void UpdateStatus(string id, string status)
        {
            var update = (from task in xml.Descendants(GlobalConstants.Task)
                          where task.Element(GlobalConstants.Id).Value == id
                          select task).Single();
            if (update != null)
            {
                update.Element(GlobalConstants.Status).Value = status;
            }
            xml.Save(fileName);
        }

        public void UpdateDate(string id, DateTime date)
        {
            var update = (from task in xml.Descendants(GlobalConstants.Task)
                          where task.Element(GlobalConstants.Id).Value == id
                          select task).Single();
            if (update != null)
            {
                update.Element(GlobalConstants.Date).Value = date.ToString("d MMM yyyy", CultureInfo.InvariantCulture);
            }
            xml.Save(fileName);
        }

        public void AddTask(string taskName, string description, DateTime date, DateTime? duDate, string status)
        {
            xml.Root.Add(new XElement(GlobalConstants.Task,
                new XElement(GlobalConstants.Id, GetTaskCount()),
                new XElement(GlobalConstants.Title, taskName),
                new XElement(GlobalConstants.Descr, description),
                new XElement(GlobalConstants.Date, date.ToString("d MMM yyyy", CultureInfo.InvariantCulture)),
                new XElement(GlobalConstants.DueDate, duDate?.ToString("d MMM yyyy hh:mm:ss.ff tt", CultureInfo.InvariantCulture)),
                new XElement(GlobalConstants.Status, status)));
            xml.Save(fileName);
        }

        private int GetTaskCount()
        {
            var tasks = from task in xml.Descendants(GlobalConstants.Task) select task;
            return tasks.Count() + 1;
        }

    }
}
