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
        Done
        
    }

    public class Task
    {
        private string taskName;
        private DateTime date;
        private Status status;

        public Task()
        {          
        }

        public Task(string taskName, DateTime date, Status status)
        {
            this.taskName = taskName;
            this.date = date;
            this.status = status;
        }

        public string GetName => taskName;
        public DateTime GetDate => date;
        public Status GetStatus => status;
    }


    public class TaskManager<Task>:ICollection<Task>
    {     
        private List<Task> tasks = new List<Task>();
        private int count=0;
                      
        public void Add(Task newTask)
        {
            if (newTask == null) throw new ArgumentNullException();
            tasks.Add(newTask);
            count++;
        }       

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Task item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Task[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Task item)
        {
            throw new NotImplementedException();
        }

        IEnumerator<Task> IEnumerable<Task>.GetEnumerator()
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
        public List<Task> Tasks => tasks; 
        public object SyncRoot { get; }
        public bool IsSynchronized { get; }
    }
}
