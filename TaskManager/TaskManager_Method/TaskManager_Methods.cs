using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskManager_Method
{
    public class TaskManager_Methods:ICollection
    {     
        private List<string> tasks = new List<string>();
        private int count=0;
                      
        public void Add(string newTask)
        {
            tasks.Add(newTask);
            count++;
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
        public List<string> Tasks => tasks; 
        public object SyncRoot { get; }
        public bool IsSynchronized { get; }
    }
}
