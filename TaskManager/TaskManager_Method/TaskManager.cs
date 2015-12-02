﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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
        private int id;

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


    public class TaskManager<Task>:ICollection<Task>
    {
        private List<Task> tasks = new List<Task>();
        private int count;

        public void Add(Task newTask)
        {
            if (newTask == null) throw new ArgumentNullException();
            tasks.Add(newTask);
            count++;
        }

        public void SaveTask(string task)
        {
            using (var writer = new StreamWriter(@"C:\Users\Administrator\Documents\Visual Studio 2015\Projects\TaskManager\Tasks.txt", true))
            {
                writer.WriteLine(task);
            }
        }

        public string[] GetTask()
        {
            return File.ReadAllLines((@"C:\Users\Administrator\Documents\Visual Studio 2015\Projects\TaskManager\Tasks.txt"));                   
        }

        public void Update(int id)
        {
            StreamReader reading =
                File.OpenText(@"C:\Users\Administrator\Documents\Visual Studio 2015\Projects\TaskManager\Tasks.txt");
            string str;
            while ((str = reading.ReadLine()) != null)
            {
                if (str.Contains("id"))
                {
                    str.Replace("To Do", "Done");
                    File.WriteAllText(@"C:\Users\Administrator\Documents\Visual Studio 2015\Projects\TaskManager\Tasks.txt", str);
                }
            }
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
