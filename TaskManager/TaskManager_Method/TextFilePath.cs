using System;
using System.IO;
using System.Reflection;

namespace TaskManager
{
    public class TextFilePath
    {
        private string actualPath;

        public TextFilePath()
        {
            this.actualPath = GetActualPath();
        }
        public string GetActualPath()
        {
            return AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        }

        public bool ValidatePath(string name)
        {
            return File.Exists(actualPath + name);
        }

        public string FilePath(string name)
        {
            if (!ValidatePath(name))
                return Path.Combine(actualPath, name);
            return actualPath + name;
        }
    }
}