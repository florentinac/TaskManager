using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TaskManager
{
    public class CreateXMLDoc
    {
        private string fileName;      
     
        public CreateXMLDoc(string fileName)
        {
            //this.writer = new XmlTextWriter(fileName, System.Text.Encoding.UTF8);
            this.fileName = fileName;
        }


        public void AddNewNode(string taskName, string description, DateTime? date, DateTime? duDate, string status)
        {
            if(!File.Exists(fileName))
                CreatedXMLFile(taskName, description, date, duDate, status);
            else
            {
                //AppendNode();
            }
           
        }

        public void CreateNode(string taskName, string description, DateTime? date, DateTime? duDate, string status, XmlTextWriter writer)
        {
            writer.WriteStartElement("Task");
            writer.WriteStartElement("Id");
            writer.WriteString("1");
            writer.WriteEndElement();
            writer.WriteStartElement("Title");
            writer.WriteString(taskName);
            writer.WriteEndElement();
            writer.WriteStartElement("Description");
            writer.WriteString(description);
            writer.WriteEndElement();
            writer.WriteStartElement("Date");
            writer.WriteString(date.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("DuDate");
            writer.WriteString(duDate.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("Status");
            writer.WriteString(status);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        public void AppendNode(string taskName, string description, DateTime? date, DateTime? duDate, string status)
        {

        }

        public bool ExistXMLDoc()
        {                 
            return File.Exists(fileName);
        }
        public void CreatedXMLFile(string taskName, string description, DateTime? date, DateTime? duDate, string status)
        {
            var writer = new XmlTextWriter(fileName, System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("TaskManager");
            CreateNode(taskName, description, date, duDate, status, writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            Console.WriteLine("XML File created and the Task is Added! ");            
        }

        private static void ReadXml()
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            string str = null;
            FileStream fs = new FileStream("product.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("Task");
            for (i = 0; i < xmlnode.Count; i++)
            {
                xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                str = xmlnode[i].ChildNodes.Item(0).InnerText.Trim() + " " +
                      xmlnode[i].ChildNodes.Item(1).InnerText.Trim() + " " +
                      xmlnode[i].ChildNodes.Item(2).InnerText.Trim() + " " +
                      xmlnode[i].ChildNodes.Item(3).InnerText.Trim() + " " +
                      xmlnode[i].ChildNodes.Item(4).InnerText.Trim() + " " +
                      xmlnode[i].ChildNodes.Item(5).InnerText.Trim();
                Console.WriteLine(str);
            }
        }
    }
}
