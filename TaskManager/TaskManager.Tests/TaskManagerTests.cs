using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using TaskManager_Method;

namespace TaskManager.Tests
{
    [TestClass]
    public class TaskManagerTests
    {
        [TestMethod]
        public void TestAddTask()
        {
            var taskManager  = new TaskManager_Methods();
            var newTask = "Go to school";
            taskManager.Add(newTask);
            taskManager.ShouldNotBeEmpty();
        }
    }
}
