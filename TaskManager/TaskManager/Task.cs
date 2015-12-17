namespace TaskManager
{
    using System;
    using System.Globalization;

    public class Task
    {
        private string taskName;
        private DateTime date;
        private string status;
        private string description;
        private DateTime? dueDate;

        public Task()
        {
        }

        public Task(string taskName, string description, DateTime date, DateTime? dueDate, string status)
        {
            this.taskName = taskName;
            this.description = description;
            this.date = date;
            this.dueDate = dueDate;
            this.status = status;
        }

        public string GetTaskString(Task task, int count)
        {
            var taskString = "[NewTask]" + " " + count + " " + task.taskName + " " + task.description + " " +
                              task.date.ToString("d", CultureInfo.InvariantCulture) + " " + task.dueDate?.ToString("G", CultureInfo.InvariantCulture) + " " + task.status;
            return taskString;
        }

        public void Save(Repository repo)
        {
            repo.AddTask(taskName, description, date, dueDate, status);
        }
    }
}
