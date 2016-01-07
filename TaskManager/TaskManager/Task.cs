
namespace TaskManager
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Globalization;


    [DataContract(Name = "TaskManager", Namespace = "http://www.contoso.com")]
    public class Task : IExtensibleDataObject
    {
        [DataMember]
        private string taskName;
        [DataMember]
        private string description;
        [DataMember]
        private DateTime date;
        [DataMember]
        private DateTime? dueDate;
        [DataMember]
        private string status;             
        [DataMember]
        private string category;

        public Task()
        {
        }

        public Task(string taskName, string description, DateTime date, DateTime? dueDate, string status, string category)
        {
            this.taskName = taskName;
            this.description = description;
            this.date = date;
            this.dueDate = dueDate;
            this.status = status;
            this.category = category;
        }

        private ExtensionDataObject extensionData_Value;

        public ExtensionDataObject ExtensionData
        {
            get
            {
                return extensionData_Value;
            }
            set
            {
                extensionData_Value = value;
            }
        }

        //public void Save(XMLRepository repo)
        //{
        //    repo.AddTask(taskName, description, date, dueDate, status, category);
        //}
    }
}
