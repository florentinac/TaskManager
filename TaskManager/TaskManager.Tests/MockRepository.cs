using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskManager.Tests
{
    class MockRepository : IRepository<Task>
    {
        private List<Task> mockTask;

        public void AddTask(Task task)
        {
            mockTask.Add(task);
        }

        public IEnumerable<Task> GetAllTask()
        {
            throw new NotImplementedException();
        }

        public void UpdateDate(int id, DateTime date)
        {
            throw new NotImplementedException();
        }

        public void UpdateStatus(int id, string status)
        {
            throw new NotImplementedException();
        }
    }
}
