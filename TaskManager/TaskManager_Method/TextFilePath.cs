namespace TaskManager
{
    using System;
    using System.IO;

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

        public bool FilePath(string name, out string path)
        {
            if (!ValidatePath(name))
            {
                path = Path.Combine(actualPath, name);
                return false;
            }
            path = actualPath + name;
            return true;
        }
    }
}