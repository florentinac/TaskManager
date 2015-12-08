using System;
using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using TaskManager;
using System.Collections;

namespace TaskManager.Tests
{   
       [TestClass]
    public class TaskManagerTests
    {
        [TestMethod]
        public void TestAddAndSaveTask()
        {
            var stringTasks = new ClassIStringTasks();
            var taskManager = new TaskFunctionality(stringTasks);
            taskManager.Add("test", DateTime.Now.ToString("d"), "Tasks.txt");
            taskManager.Count.ShouldEqual(1);
        }      

        [TestMethod]
        public void TestCountWhenAddTwoTask()
        {
            var stringTasks = new ClassIStringTasks();
            var taskManager = new TaskFunctionality(stringTasks);       
            taskManager.Add("test", "10-12-2013", "Tasks.txt");
            taskManager.Add("test2", "10-12-2013", "Tasks.txt");
            taskManager.Count.ShouldEqual(2);
        }

        [TestMethod]
        public void TestGetTaskWhenAddTwoTasks()
        {          
            var stringTasks = new ClassIStringTasks();           
            var taskManager = new TaskFunctionality(stringTasks);
            taskManager.Add("test", DateTime.Now.ToString("d"), "Tasks.txt");
            taskManager.Add("test2", DateTime.Now.ToString("d"), "Tasks.txt");
            var tasks = taskManager.GetTask("Tasks.txt");
            var expectedResult = new[] {"1 test " + DateTime.Now.ToString("d") + " ToDo", "2 test2 " + DateTime.Now.ToString("d") + " ToDo"};
            CollectionAssert.AreEqual(tasks,expectedResult);          
        }

        [TestMethod]
        public void TestUpdateStatusTasks()
        {
            var stringTasks = new ClassIStringTasks();
            var taskManager = new TaskFunctionality(stringTasks);
            taskManager.Add("test", DateTime.Now.ToString("d"), "Tasks.txt");
            taskManager.Add("test2", DateTime.Now.ToString("d"), "Tasks.txt");
            var tasks = taskManager.GetTask("Tasks.txt");
            var expectedResult = new[] {"1 test " + DateTime.Now.ToString("d") + " ToDo","2 test2 " + DateTime.Now.ToString("d") + " ToDo" };
            CollectionAssert.AreEqual(tasks, expectedResult);
            taskManager.UpdateStatus("1", "Done", "Tasks.txt");
            var expectedResultAfterUpdate = new[] {"[NewTask]" + " " + "1 test " + DateTime.Now.ToString("d") + " Done", "[NewTask]" + " " + "2 test2 " + DateTime.Now.ToString("d") + " ToDo" };
            CollectionAssert.AreEqual(stringTasks, expectedResultAfterUpdate);
        }

        [TestMethod]
        public void TestUpdateDateTasks()
        {
            var stringTasks = new ClassIStringTasks();
            var taskManager = new TaskFunctionality(stringTasks);
            taskManager.Add("test", DateTime.Now.ToString("d"), "Tasks.txt");
            taskManager.Add("test2", DateTime.Now.ToString("d"), "Tasks.txt");
            var tasks = taskManager.GetTask("Tasks.txt");
            var expectedResult = new[] { "1 test " + DateTime.Now.ToString("d") + " ToDo", "2 test2 " + DateTime.Now.ToString("d") + " ToDo" };
            CollectionAssert.AreEqual(tasks, expectedResult);
            taskManager.UpdateDate("2","11/17/16","Tasks.txt");
            var expectedResultAfterUpdate = new[] { "[NewTask]" + " " + "1 test " + DateTime.Now.ToString("d") + " ToDo", "[NewTask]" + " " + "2 test2 17/11/16 ToDo" };
            CollectionAssert.AreEqual(stringTasks, expectedResultAfterUpdate);
        }
    }
}
