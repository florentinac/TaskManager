using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using TaskManager;

namespace TaskManager.Tests
{
    public class MuckStringAdd : IFileWrite
    {
        public void WriteLine(string name, string path)
        {
        }
    }

    [TestClass]
    public class TaskManagerTests
    {
        [TestMethod]
        public void TestAddAndSaveTask()
        {           
            var taskManager = new TaskFunctionality();
            taskManager.Add("test", DateTime.Now, "Tasks.txt");
            taskManager.Count.ShouldEqual(1);
        }

        [TestMethod]
        public void TestAddTaskAndChangeDate()
        {       
            var taskManager = new TaskFunctionality();
            var date = DateTime.ParseExact("26-02-2015", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            taskManager.Add("test", date, "Tasks.txt");
            taskManager.Count.ShouldEqual(1);
        }

        [TestMethod]
        public void TestPathAndGetTaskNull()
        {
            var textPath = new TextFilePath();
            textPath.ValidatePath("Tasks.txt").ShouldBeFalse();
            var taskManagere = new TaskFunctionality();
            var tasks = taskManagere.GetTask("Tasks.txt");
            tasks.ShouldBeNull();
        }

      



    }
}
