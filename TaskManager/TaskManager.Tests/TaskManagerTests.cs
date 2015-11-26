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
            taskManager.Count.ShouldEqual(1);
        }

        [TestMethod]
        public void TestAddMultipayTask()
        {
            var taskManager = new TaskManager_Methods();
            var newTask = "Go to work";
            var secondTask = "Go to school";
            taskManager.Add(newTask);
            taskManager.Add(secondTask);
            taskManager.ShouldNotBeEmpty();
            taskManager.Count.ShouldEqual(2);
            taskManager.Tasks.ShouldContain(secondTask);
            taskManager.Tasks.ShouldContain(newTask);
        }
    }
}
