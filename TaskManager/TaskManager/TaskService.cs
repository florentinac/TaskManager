using System.Collections.Generic;

namespace TaskManager
{
    using System;

    public class TaskService
    {
        private XMLRepository repository;

        public TaskService(string fileName)
        {
            this.repository = new XMLRepository(fileName);
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return repository.GetAllTask();
        }

        public void UpdateStatus(int id, string status)
        {
            repository.UpdateStatus(id, status);
        }

        public void UpdateDate(int id, DateTime date)
        {
            repository.UpdateDate(id, date);
        }

        public void AddTask(Task task)
        {
           repository.AddTask(task);
        }
    }
}
