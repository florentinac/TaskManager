namespace TaskManager
{
    using System;

    public class TaskService
    {
        private Repository repository;

        public TaskService(string fileName)
        {
            this.repository = new Repository(fileName);
        }

        public void GetTasks()
        {
            repository.GetTasks();
        }

        public void UpdateStatus(string id, string status)
        {
            repository.UpdateStatus(id, status);
        }

        public void UpdateDate(string id, DateTime date)
        {
            repository.UpdateDate(id, date);
        }

        public void AddTask(Task task)
        {
            task.Save(repository);
        }

        //public void Add(string taskName, string description, DateTime date, DateTime? dueDate, string status)
        //{
        //    repository.AddTask(taskName, description, date, dueDate, status);
        //}
    }
}
