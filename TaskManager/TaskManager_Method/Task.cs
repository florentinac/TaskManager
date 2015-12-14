namespace TaskManager
{
    using System;
    using System.Globalization;

    class Task
    {
        public enum Status
        {
            ToDo,
            Done
        }

        private string taskName;
        private DateTime date;
        private Status status;
        private string description;
        private DateTime? duDate;

        public Task()
        {
        }

        public Task( string taskName, string description, DateTime date, DateTime? duDate, Status status)
        {            
            this.taskName = taskName;
            this.description = description;
            this.date = date;
            this.duDate = duDate;
            this.status = status;
        }
    
        public string GetTaskString(Task task, int count)
        {
            var taskString = "[NewTask]" + " " + count + " " + task.taskName + " " + task.description + " "+ 
                              task.date.ToString("d",CultureInfo.InvariantCulture) + " " + task.duDate?.ToString("G", CultureInfo.InvariantCulture) + " " + task.status;
            return taskString;
        }

        public static void StatusSaveTask(string fileName, Task newTask)
        {
           var createXmlDoc = new CreateXMLDoc(fileName);
           createXmlDoc.AddNewNode(newTask.taskName, newTask.description, newTask.date, newTask.duDate, newTask.status.ToString());
        }
    }
}
