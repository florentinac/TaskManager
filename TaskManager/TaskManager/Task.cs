using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public class Task
    {
        private string taskName;
        private DateTime date;
        private string status;
        private string description;
        private DateTime? duDate;

        public Task()
        {
        }

        public Task(string taskName, string description, DateTime date, DateTime? duDate, string status)
        {
            this.taskName = taskName;
            this.description = description;
            this.date = date;
            this.duDate = duDate;
            this.status = status;
        }

        public string GetTaskString(Task task, int count)
        {
            var taskString = "[NewTask]" + " " + count + " " + task.taskName + " " + task.description + " " +
                              task.date.ToString("d", CultureInfo.InvariantCulture) + " " + task.duDate?.ToString("G", CultureInfo.InvariantCulture) + " " + task.status;
            return taskString;
        }

        public void Save(Repository repo)
        {
            repo.AddTask(this.taskName, this.description, this.date, this.duDate, this.status);
        }
    }
}
