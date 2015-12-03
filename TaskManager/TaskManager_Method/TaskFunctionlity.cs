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

    public class TaskFunctionality : ICollection<Task>
    {
        private List<Task> tasks = new List<Task>();
        private int count;
        private TextFilePath textFilePath = new TextFilePath();

        public void Add(string taskName, DateTime data)
        {
            var newTask = new Task(1, taskName, data, Status.ToDo);
            tasks.Add(newTask);
            ReturnNoLine(out count);
            var taskFile = count + " " + newTask.GetName + " " + newTask.GetDate + " " + newTask.GetStatus;
            SaveTask(taskFile);
        }

        private void ReturnNoLine(out int count)
        {
            count = 1;
            if (!textFilePath.ValidatePath("Tasks.txt"))
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

        private void SaveTask(string task)
        {
            var path = textFilePath.FilePath("Tasks.txt");
            using (var writer = new StreamWriter(path, true))
            {
                writer.WriteLine(task);
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

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Task item)
        {
            var task = GetTask("Tasks.txt");
            for (var j = 0; j < task.Length;)
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
