namespace TaskManager
{
    public interface IFileWrite
    {
        void WriteLine(string task, string path, string fileName);
        void GetId(string fileName, out int count);
        string[] GetTasks(string fileName, int count);
        void Update(string[] tasks);
        string[] GetEntiyerTasks(string fileName, int count);
        void Sort(string[] tasks);
    }
}