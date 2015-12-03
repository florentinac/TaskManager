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
            string path;
            var newTask = new Task(1, taskName, data, Task.Status.ToDo);        
            tasks.Add(newTask);
            ReturnNoLine(fileName, out count);
            var taskFile = count + " " + newTask.GetName + " " + newTask.GetDate + " " + newTask.GetStatus;
            textFilePath.FilePath(fileName, out path);
            fileWrite.WriteLine(taskFile, path);
           // SaveTask(taskFile, path);
        }

        private void ReturnNoLine(string fileName, out int count)
        {
            count = 1;            
            if (!textFilePath.ValidatePath(fileName))
                return;
            using (var reader = File.OpenText(textFilePath.FilePath(fileName)))
            {
                while (reader.ReadLine() != null)
                {
                    count++;
                }
            }
        }

        public string[] GetTask(string fileName)
        {
            if (!textFilePath.ValidatePath(fileName))
                return null;
            if (new FileInfo(textFilePath.FilePath(fileName)).Length == 0)
                return null;
            return File.ReadAllLines(textFilePath.FilePath(fileName));
        }

        public void Update(string id)
        {
            var tasks = GetTask("Tasks.txt");
            if (tasks == null) return;
            for (var i = 0; i < tasks.Length; i++)
            {
                var splitTask = tasks[i].Split(' ');
                if (splitTask[0].Equals(id))
                {
                    var output = tasks[i].Replace("ToDo", "Done");
                    tasks[i] = output;
                    File.WriteAllLines(textFilePath.FilePath("Tasks.txt"), tasks);
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

    public class ClassIFileWriter : IFileWrite
    {
        public void WriteLine(string task, string path)
        {
            using (var writer = new StreamWriter(path, true))
            {
                writer.WriteLine(task);
            }
        }
    }

}
