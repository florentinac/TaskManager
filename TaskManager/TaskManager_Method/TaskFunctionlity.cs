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
        private IFileWrite fileWrite;

        public TaskFunctionality()
        {
            fileWrite = new ClassIFileWriter();
        }

        public TaskFunctionality(IFileWrite fileWrite)
        {
            this.fileWrite = fileWrite;
        }

        public void Add(string taskName, string txtDate, string fileName)
        {
            if (fileName == null)
                fileName = "Tasks.txt";

            var tempDate = TempDate(txtDate);
            string path = null;
            var newTask = new Task(1, taskName, tempDate, Task.Status.ToDo); 
                   
            tasks.Add(newTask);
            fileWrite.GetId(fileName, out count);           
                       
            var taskFile ="[NewTask]" + " " + count + " " + newTask.GetName + " " + newTask.GetDate + " " + newTask.GetStatus;
            fileWrite.WriteLine(taskFile, path, fileName);           
        }

        private static DateTime TempDate(string txtDate)
        {
            DateTime tempDate;
            if (!DateTime.TryParse(txtDate, out tempDate))
            {
                tempDate = DateTime.Now;
                Console.WriteLine("The Date is invalid, will be set to the current day");
            }
            return tempDate;
        }        

        public string[] GetTask(string fileName)
        {
            if (fileName == null)
                fileName = "Tasks.txt";
            var result = fileWrite.GetTasks(fileName, count);
            if (result == null)
            {
                Console.WriteLine("First you must add some Tasks");
            }else
                foreach (var task in result)
                    Console.WriteLine(task);
            return result;
        }

        public void UpdateStatus(string id, string status, string fileName)
        {
            var entryTask = new ClassIFileWriter();
            if (status == null)
                status = "Done";
            var tasks = entryTask.GetEntiyerTasks("Tasks.txt", count);
            if (tasks == null) return;
            for (var i = 0; i < tasks.Length; i++)
            {
                var splitTask = tasks[i].Split(' ');
                if (splitTask[0].Equals(id))
                {
                    var output = tasks[i].Replace("ToDo", status);
                    tasks[i] = output;
                    fileWrite.Update(tasks);                   
                }                   
            }
        }

        public void UpdateDate(string id, string date, string fileName)
        {
            var entryTask = new ClassIFileWriter();
            var tasks = entryTask.GetEntiyerTasks(fileName, count);
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
