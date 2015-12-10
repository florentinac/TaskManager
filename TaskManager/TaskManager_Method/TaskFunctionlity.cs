namespace TaskManager
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class TaskFunctionality : ICollection
    {
        private List<Task> tasks = new List<Task>();
                   
        private IFileWrite fileWrite;
        private int count;

        public TaskFunctionality()
        {
            fileWrite = new ClassIFileWriter();
        }

        public TaskFunctionality(IFileWrite fileWrite)
        {
            this.fileWrite = fileWrite;
        }

        public void Add(string taskName, string description, string txtDate, string txtDuDate, string fileName)
        {           
            fileName = Validator.FileName(fileName);
            var tempDate = Validator.TempDate(txtDate);
            var tempDuDate = Validator.DuTempDate(txtDuDate);
            if(tempDuDate!=null)
                if (!Validator.DuDate(tempDuDate, tempDate))
                {
                    return;
                }
   
            var newTask = new Task(taskName, description, tempDate, tempDuDate, Task.Status.ToDo); 
                   
            tasks.Add(newTask);            
            SaveTask(fileName, newTask);
        }

        private void SaveTask(string fileName, Task newTask)
        {
            string path = null;
            fileWrite.GetId(fileName, out count);
            var taskstring = newTask.GetTaskString(newTask, count);

            fileWrite.WriteLine(taskstring, path, fileName);
        }


        public string[] GetTask(string fileName)
        {
            fileName = Validator.FileName(fileName);
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
            status = Validator.Status(status);
            fileName = Validator.FileName(fileName);
            if (!IsTasks(fileName, out tasks)) return false;
            return true;
        }

        public void UpdateDate(string id, string date, string fileName)
        {
            string[] tasks;
            fileName = Validator.FileName(fileName);
            DateTime tempDate = Validator.TempDate(date);          
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

        public void SortAscending(string fileName)
        {           
            var tasks = fileWrite.GetTasks(fileName, count);
            DateTime[] date = new DateTime[tasks.Length];
            GetDateFromString(tasks, date);
            SortTasksAscending(date,ref tasks);         
           
            fileWrite.Sort(tasks);

        }
        public void SortDescending(string fileName)
        {
            var tasks = fileWrite.GetTasks(fileName, count);
            DateTime[] date = new DateTime[tasks.Length];
            GetDateFromString(tasks, date);
            SortTasksDescending(date, ref tasks);

            fileWrite.Sort(tasks);

        }

        private static void GetDateFromString(string[] tasks, DateTime[] date)
        {
            for (var i = 0; i < tasks.Length; i++)
            {
                var splitTask = tasks[i].Split(' ');
                for (var j = 0; j < splitTask.Length; j++)
                {
                    DateTime tempDate;
                    if (DateTime.TryParse(splitTask[j], out tempDate))
                    {
                        date[i] = tempDate;
                    }
                }
            }
        }
        private static void SortTasksDescending(DateTime[] date, ref string[] tasks)
        {
            for (var i = 1; i < date.Length; i++)
                for (var k = i; k > 0; k--)
                {
                    TimeSpan difference = date[k] - date[k - 1];
                    double days = difference.TotalDays;
                    if (days > 0)
                    {
                        Swap(ref tasks[k], ref tasks[k - 1]);
                        Swap(ref date[k], ref date[k - 1]);
                    }

                }
        }
        private static void SortTasksAscending(DateTime[] date, ref string[] tasks)
        {
            for (var i = 1; i < date.Length; i++)
                for(var k=i;k>0;k--)
                { 
                    TimeSpan difference = date[k] - date[k - 1];
                    double days = difference.TotalDays;
                    if (days < 0)
                    {
                        Swap(ref tasks[k], ref tasks[k - 1]);
                        Swap(ref date[k], ref date[k-1]);
                    }

                }                      
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            var temp = x;
            x = y;
            y = temp;
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


        public void Search(string word, string fileName)
        {
            if (fileName == null)
                fileName = "Tasks.txt";
            var tasks = fileWrite.GetTasks(fileName, count);
            for (var i = 0; i < tasks.Length-1; i++)
            {
                var task = tasks[i].Split(' ');
                WriteMatchTasks(word, task);
            }
            var taskLast = tasks[tasks.Length - 1].Split(' ');
            WriteMatchTasks(word, taskLast);
        }

        private static void WriteMatchTasks(string word, string[] taskLast)
        {
            for (var j = 0; j < taskLast.Length; j++)
                if (String.Equals(taskLast[j], word, StringComparison.OrdinalIgnoreCase))
                {
                    for (var k = 0; k < j; k++)
                        Console.Write(taskLast[k] + " ");
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(taskLast[j]);
                    Console.ResetColor();                  
                    for (var k = j + 1; k < taskLast.Length-1; k++)
                        Console.Write(" "+ taskLast[k]);
                    Console.WriteLine(taskLast[taskLast.Length-1]);
                }
        }
    }

   

}
