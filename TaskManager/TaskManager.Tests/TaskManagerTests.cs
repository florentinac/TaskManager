using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using TaskManager;

namespace TaskManager.Tests
{
    [TestClass]
    public class TaskManagerTests
    {

        [TestMethod]     
        public void TestAddTask()
        {
            var task = new Task(1,"Go to school", DateTime.Today, Status.ToDo);          
            var taskManager  = new TaskFunctionality();
            taskManager.Add(task);                 
            taskManager.Count.ShouldEqual(1);
        }

        [TestMethod]
        public void TestAddMultipayTask()
        {
            var newTask = new Task(1,"Go to school", DateTime.Today, Status.ToDo);
            var secondTask = new Task(2,"Go to school", DateTime.Today, Status.ToDo);
            var taskManager = new TaskFunctionality();
           
            taskManager.Add(newTask);
            taskManager.Add(secondTask);
            taskManager.ShouldNotBeEmpty();
            taskManager.Count.ShouldEqual(2);
            taskManager.Tasks.ShouldContain(secondTask);
            taskManager.Tasks.ShouldContain(newTask);
        }

        [TestMethod]
        public void TestAdd2Task()
        {
            //var task = new Task(1, "Go to school", DateTime.Today, Status.ToDo);
            var taskManager = new TaskFunctionality();
            taskManager.Add("test");
            taskManager.Count.ShouldEqual(1);
        }

    }
}
