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
            var task = new Task("Go to school", DateTime.Today, Status.ToDo);          
            var taskManager  = new TaskManager<Task>();
            taskManager.Add(task);           
            //taskManager.Add(task);
            taskManager.Count.ShouldEqual(1);
        }

        [TestMethod]
        public void TestAddMultipayTask()
        {
            var newTask = new Task("Go to school", DateTime.Today, Status.ToDo);
            var secondTask = new Task("Go to school", DateTime.Today, Status.ToDo);
            var taskManager = new TaskManager<Task>();
           
            taskManager.Add(newTask);
            taskManager.Add(secondTask);
            taskManager.ShouldNotBeEmpty();
            taskManager.Count.ShouldEqual(2);
            taskManager.Tasks.ShouldContain(secondTask);
            taskManager.Tasks.ShouldContain(newTask);
        }
    }
}
