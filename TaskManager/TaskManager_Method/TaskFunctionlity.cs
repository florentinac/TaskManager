using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskManager
{
    public enum Status
    {
        ToDo,  
        Done        
    }
     
    public class Task
    {
       
        protected string taskName;
        private DateTime date;
        private Status status;
        protected int id;

        public Task()
        {
        }

        public Task(int id, string taskName, DateTime date, Status status)
        {
            this.id = id;
            this.taskName = taskName;
            this.date = date;
            this.status = status;

        }

        public string GetName => taskName;
        public string GetDate => date.ToString("dd/MM/yy");
        public string GetStatus => status.ToString();
        public int GetId => id;
    }  

    public class TaskFunctionality:ICollection<Task>
    {
        private List<Task> tasks = new List<Task>();
        private int count;
        private TextFilePath textFilePath = new TextFilePath();

        public void Add(string taskName)
        {
            var newTask = new Task(1, taskName, DateTime.Now, Status.ToDo);           
            tasks.Add(newTask);
            ReturnNoLine(out count);
            var taskFile = count + " " + newTask.GetName + " " + newTask.GetDate + " " + newTask.GetStatus;
            SaveTask(taskFile);

        }

        private void ReturnNoLine(out int count)
        {
            count= 1;
            if (!File.Exists(textFilePath.FilePath("Tasks.txt")))              
                return;
            using (var reader = File.OpenText(textFilePath.FilePath("Tasks.txt")))
            {
                while (reader.ReadLine() != null)
                {
                    count++;
                }
            }          
        }

        public void Add(Task newTask)
        {
            if (newTask == null) throw new ArgumentNullException();
            tasks.Add(newTask);
            count++;            
        }

        public void SaveTask(string task)
        {
            var path = textFilePath.FilePath("Tasks.txt");
            using (var writer = new StreamWriter(path, true))
            {
                writer.WriteLine(task);
            }
            
        }

        public string[] GetTask()
        {
            var path = textFilePath.FilePath("Tasks.txt");
            if (new FileInfo(path).Length == 0)
                return null;
            return File.ReadAllLines(textFilePath.FilePath("Tasks.txt"));                   
        }

        public void Update(int id)
        {
            StreamReader reading =
                File.OpenText(textFilePath.FilePath("Tasks.txt"));
            string str;
            while ((str = reading.ReadLine()) != null)
            {
                if (str.Contains("id"))
                {
                    str.Replace("To Do", "Done");
                    File.WriteAllText(textFilePath.FilePath("Tasks.txt"), str);
                }
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }
       

        public bool Contains(Task item)
        {           
            var task = GetTask();
            for(var j=0;j<task.Length;)
            if (task.Equals(item.GetId))
                return true;
            return false;
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
