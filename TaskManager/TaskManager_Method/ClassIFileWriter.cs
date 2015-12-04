using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public class ClassIFileWriter : IFileWrite
    {
        private TextFilePath textFilePath = new TextFilePath();

        private void  GetPath(string fileName, out string path)
        {
            textFilePath.FilePath(fileName, out path);
        }

        public void WriteLine(string task, string path, string fileName)
        {    
            GetPath(fileName, out path);
            using (var writer = new StreamWriter(path, true))
            {
                writer.WriteLine(task);
            }
        }

        public void NoLine(string fileName, out int count)
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

        public string[] GetTasks(string fileName, int count)
        {
            if (!textFilePath.ValidatePath(fileName))
                return null;
            if (new FileInfo(textFilePath.FilePath(fileName)).Length == 0)
                return null;
            return File.ReadAllLines(textFilePath.FilePath(fileName));
        }

        public void Update(string[] tasks)
        {
            File.WriteAllLines(textFilePath.FilePath("Tasks.txt"), tasks);
        }
    }
}
