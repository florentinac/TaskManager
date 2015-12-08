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
                       
            var taskFile ="[NewTask]" + " " + count + " " + newTask.GetName + " " + tempDate.ToString("d") + " " + newTask.GetStatus;
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
            string[] tasks;
            if (!ValidationOfParameters(ref status, ref fileName, out tasks)) return;
            for (var i = 0; i < tasks.Length; i++)
            {
                var splitTask = tasks[i].Split(' ');
                if (splitTask[1].Equals(id))
                {
                    var output = tasks[i].Replace("ToDo", status);
                    tasks[i] = output;
                    fileWrite.Update(tasks);                   
                }                   
            }
        }

        private bool ValidationOfParameters(ref string status, ref string fileName, out string[] tasks)
        {            
            if (status == null)
                status = "Done";
            if (fileName == null)
                fileName = "Tasks.txt";
            if (!IsTasks(fileName, out tasks)) return false;
            return true;
        }

        public void UpdateDate(string id, string date, string fileName)
        {
            string[] tasks;
            if (fileName == null)
                fileName = "Tasks.txt";
            DateTime tempDate = TempDate(date);          
            if (!IsTasks(fileName, out tasks)) return;
            for (var i = 0; i < tasks.Length; i++)
            {
                var splitTask = tasks[i].Split(' ');
                if (splitTask[1].Equals(id))
                {
                    var output = tasks[i].Replace(splitTask[3], tempDate.ToString("dd/MM/yy"));
                    tasks[i] = output;
                    fileWrite.Update(tasks);
                }
            }
        }

        private bool IsTasks(string fileName, out string[] tasks)
        {           
            tasks = fileWrite.GetEntiyerTasks(fileName, count);
            if (tasks == null) return false;
            return true;
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
