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
            var task = new Task(1, "Go to school", DateTime.Today, Status.ToDo);
            var taskManager = new TaskFunctionality();
            taskManager.Add(task);
            taskManager.Count.ShouldEqual(1);
        }

        [TestMethod]
        public void TestAddMultipayTask()
        {
            var newTask = new Task(1, "Go to school", DateTime.Today, Status.ToDo);
            var secondTask = new Task(2, "Go to school", DateTime.Today, Status.ToDo);
            var taskManager = new TaskFunctionality();

            taskManager.Add(newTask);
            taskManager.Add(secondTask);
            taskManager.ShouldNotBeEmpty();
            taskManager.Count.ShouldEqual(2);
            taskManager.Tasks.ShouldContain(secondTask);
            taskManager.Tasks.ShouldContain(newTask);
        }

        [TestMethod]
        public void TestAddAndSaveTask()
        {           
            var taskManager = new TaskFunctionality();
            taskManager.Add("test", DateTime.Now);
            taskManager.Count.ShouldEqual(1);
        }

        [TestMethod]
        public void TestAddTaskAndChangeDate()
        {       
            var taskManager = new TaskFunctionality();
            var date = DateTime.ParseExact("26-02-2015", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            taskManager.Add("test", date);
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
