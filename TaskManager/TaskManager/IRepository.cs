using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAllTask();
        void UpdateStatus(int id, string status);
        void UpdateDate(int id, DateTime date);
        void AddTask(T task);
    }
}
