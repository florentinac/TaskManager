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
            this.actualPath = GetPath();
        }
        private string GetPath()
        {
            return actualPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        }

        public string FilePath(string name)
        {
            if(!File.Exists(actualPath+name))
                return Path.Combine(actualPath,name);
            return actualPath + name;
        }       
    }
}