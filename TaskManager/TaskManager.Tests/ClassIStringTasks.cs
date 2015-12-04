using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Tests
{
    public class ClassIStringTasks : IFileWrite, ICollection
    {
        public string[] tasksString = new string[10];

        public int Count => tasksString.Length;

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public void WriteLine(string name, string path, string fileName)
        {
            for (int i = 0; i <= tasksString.Length; i++)
                if (tasksString[i] == null)
                {
                    tasksString[i] += name;
                    return;
                }
        }

        public void NoLine(string name, out int count)
        {
            count = 1;
            for (int i = 0; i < tasksString.Length; i++)
                if (tasksString[i] != null)
                    count++;
        }

        public string[] GetTasks(string name, int count)
        {
            var result = new string[count];
            for (var i = 0; i < count; i++)
                if (tasksString[i] != null)
                    result[i] = tasksString[i];
            return result;

        }

        public void Update(string[] tasks)
        {
            tasksString = tasks;
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            for (var i = 0; i < tasksString.Length; i++)
                yield return tasksString[i];
        }
    }
}
