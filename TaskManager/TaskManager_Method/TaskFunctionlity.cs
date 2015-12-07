using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskManager
{ 
    public class TaskFunctionality : ICollection
    {
        private List<Task> tasks = new List<Task>();
        private int count;
        private TextFilePath textFilePath = new TextFilePath();
        private IFileWrite fileWrite;

        public TaskFunctionality()
        {
            fileWrite = new ClassIFileWriter();
        }

        public TaskFunctionality(IFileWrite fileWrite)
        {
            this.fileWrite = fileWrite;
        }

        public void Add(string taskName, DateTime data, string fileName)
        {
            string path = null;
            var newTask = new Task(1, taskName, data, Task.Status.ToDo);        
            tasks.Add(newTask);
            fileWrite.GetId(fileName, out count);                      
            var taskFile ="[NewTask]" + " " + count + " " + newTask.GetName + " " + newTask.GetDate + " " + newTask.GetStatus;
            fileWrite.WriteLine(taskFile, path, fileName);           
        }

       

        public string[] GetTask(string fileName)
        {
             return fileWrite.GetTasks(fileName, count);        
        }

        public void UpdateStatus(string id)
        {
            var tasks = fileWrite.GetTasks("Tasks.txt", count);
            if (tasks == null) return;
            for (var i = 0; i < tasks.Length; i++)
            {
                var splitTask = tasks[i].Split(' ');
                if (splitTask[0].Equals(id))
                {
                    var output = tasks[i].Replace("ToDo", "Done");
                    tasks[i] = output;
                    fileWrite.Update(tasks);                   
                }                   
            }
        }

        public void UpdateDate(string id, string date)
        {
            var tasks = fileWrite.GetTasks("Tasks.txt", count);
            if (tasks == null) return;
            for (var i = 0; i < tasks.Length; i++)
            {
                var splitTask = tasks[i].Split(' ');
                if (splitTask[0].Equals(id))
                {
                    var output = tasks[i].Replace(splitTask[2], date);
                    tasks[i] = output;
                    fileWrite.Update(tasks);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
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
        public object SyncRoot { get; }
        public bool IsSynchronized { get; }
    }

   

}
