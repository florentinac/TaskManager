﻿namespace TaskManager
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Xsl;
    using TaskManager_Method;

    public class CreateXMLDoc
    {
        private string fileName;
        protected XDocument xml;

        public CreateXMLDoc() { }

        public CreateXMLDoc(string fileName)
        {
            var validatePath = new TextFilePath();                    
            this.fileName = validatePath.FilePath(fileName);

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

        public void ReadTasks()
        {
            var tasks = from c in xml.Root.Descendants(GlobalConstants.Task)
                        select c.Element(GlobalConstants.Id).Value + " " +
                               c.Element(GlobalConstants.Title).Value + " " +
                               c.Element(GlobalConstants.Descr).Value + " " +
                               c.Element(GlobalConstants.Date).Value + " " +
                               c.Element(GlobalConstants.DuDate).Value + " " +
                               c.Element(GlobalConstants.Status).Value;
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }
            DisplayHTML(fileName);
        }

        private void DisplayHTML(string input)
        {
            var xslt = new XslCompiledTransform(true);
            xslt.Load("testhtml.xsl", XsltSettings.TrustedXslt, new XmlUrlResolver());
            xslt.Transform(input, "test.html");
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

        public void AddNewNode(string taskName, string description, DateTime date, DateTime? duDate, string status)
        {
            xml.Root.Add(new XElement(GlobalConstants.Task,
                new XElement(GlobalConstants.Id, GetTaskCount()),
                new XElement(GlobalConstants.Title, taskName),
                new XElement(GlobalConstants.Descr, description),
                new XElement(GlobalConstants.Date, date.ToString("d MMM yyyy", CultureInfo.InvariantCulture)),
                new XElement(GlobalConstants.DuDate, duDate?.ToString("d MMM yyyy hh:mm:ss.ff tt", CultureInfo.InvariantCulture)),
                new XElement(GlobalConstants.Status, status)));
            xml.Save(fileName);
        }

        public int GetTaskCount()
        {
            var tasks = from task in xml.Descendants(GlobalConstants.Task) select task;
            return tasks.Count()+1;
        }              
    }
}
