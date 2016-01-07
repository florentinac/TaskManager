using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace TaskManager
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Xml.Linq;

    public class XMLRepository : IRepository<Task>
    {
        private string fileName;
        protected FileStream fs;

        public XMLRepository()
        {
        }

        public XMLRepository(string fileName)
        {
            var path = new PathClass();
            this.fileName = path.FilePath(fileName);
        }

        //private void InitXMLDocument()
        //{
        //    try
        //    {
        //        fs = new FileStream(fileName, FileMode.Open);
        //    }
        //    catch (Exception)
        //    {
        //        fs = new FileStream(fileName, FileMode.Create);
        //    }
        //}

        public IEnumerable<Task> GetAllTask()
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            DataContractSerializer ser = new DataContractSerializer(typeof(Task));

            IEnumerable<Task> deserializedPerson = (IEnumerable<Task>) ser.ReadObject(reader, true);
            return deserializedPerson;          
        }

        public void UpdateStatus(int id, string status)
        {
            throw new NotImplementedException();
        }

        public void UpdateDate(int id, DateTime date)
        {
            throw new NotImplementedException();
        }

        public void AddTask(Task task)
        {
            fs = new FileStream("test.xml", FileMode.OpenOrCreate);
            DataContractSerializer ser =
                new DataContractSerializer(typeof (Task));
            ser.WriteObject(fs, task);
            Console.WriteLine(ser);
            fs.Close();
        }
    }
}
