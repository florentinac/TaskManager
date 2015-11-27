using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskManager_Method
{
    public enum Status
    {
        ToDo,
        InProgress,
        Done
        
    }

    public class Task
    {
        public string taskName;
        public DateTime date;
        public Status status;

        public Task()
        {          
        }

        public Task(string taskName, DateTime date, Status status)
        {
            this.taskName = taskName;
            this.date = date;
            this.status = status;
        }
    }


    public class TaskManager_Methods<T>:ICollection<T>
    {     
        private List<T> tasks = new List<T>();
        private int count=0;
                      
        public void Add(T newTask)
        {
            if (newTask == null) throw new ArgumentNullException();
            tasks.Add(newTask);
            count++;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (var i = 0; i < count; i++)
                yield return tasks[i];
        }

        public IEnumerator GetEnumerator()
        {
            for (var i = 0; i < count; i++)
                yield return tasks[i];
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count => count;
        public bool IsReadOnly { get; }
        public List<T> Tasks => tasks; 
        public object SyncRoot { get; }
        public bool IsSynchronized { get; }
    }
}
