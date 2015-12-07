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
            taskManager.Add("test", DateTime.Now, "Tasks.txt");
            taskManager.Count.ShouldEqual(1);
        }

        [TestMethod]
        public void TestAddTaskAndChangeDate()
        {       
            var stringTasks = new ClassIStringTasks();
            var taskManager = new TaskFunctionality(stringTasks);
            var date = DateTime.ParseExact("26-02-2015", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            taskManager.Add("test", date, "Tasks.txt");
            taskManager.Count.ShouldEqual(1);
        }

        [TestMethod]
        public void TestCountWhenAddTwoTask()
        {
            var stringTasks = new ClassIStringTasks();
            var taskManager = new TaskFunctionality(stringTasks);
            var date = DateTime.ParseExact("26-02-2015", "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            taskManager.Add("test", date, "Tasks.txt");
            taskManager.Add("test2", DateTime.Now, "Tasks.txt");
            taskManager.Count.ShouldEqual(2);
        }

        [TestMethod]
        public void TestGetTaskWhenAddTwoTasks()
        {          
            var stringTasks = new ClassIStringTasks();           
            var taskManager = new TaskFunctionality(stringTasks);
            taskManager.Add("test", DateTime.Now, "Tasks.txt");
            taskManager.Add("test2", DateTime.Now, "Tasks.txt");
            var tasks = taskManager.GetTask("Tasks.txt");
            var expectedResult = new[] {"1 test " + DateTime.Now.ToString("dd/MM/yy") + " ToDo", "2 test2 " + DateTime.Now.ToString("dd/MM/yy") + " ToDo"};
            CollectionAssert.AreEqual(tasks,expectedResult);          
        }

        [TestMethod]
        public void TestUpdateStatusTasks()
        {
            var stringTasks = new ClassIStringTasks();
            var taskManager = new TaskFunctionality(stringTasks);
            taskManager.Add("test", DateTime.Now, "Tasks.txt");
            taskManager.Add("test2", DateTime.Now, "Tasks.txt");
            var tasks = taskManager.GetTask("Tasks.txt");
            var expectedResult = new[] { "1 test " + DateTime.Now.ToString("dd/MM/yy") + " ToDo", "2 test2 " + DateTime.Now.ToString("dd/MM/yy") + " ToDo" };
            CollectionAssert.AreEqual(tasks, expectedResult);
            taskManager.UpdateStatus("1");
            var expectedResultAfterUpdate = new[] { "1 test " + DateTime.Now.ToString("dd/MM/yy") + " Done", "2 test2 " + DateTime.Now.ToString("dd/MM/yy") + " ToDo" };
            CollectionAssert.AreEqual(stringTasks, expectedResultAfterUpdate);
        }

        [TestMethod]
        public void TestUpdateDateTasks()
        {
            var stringTasks = new ClassIStringTasks();
            var taskManager = new TaskFunctionality(stringTasks);
            taskManager.Add("test", DateTime.Now, "Tasks.txt");
            taskManager.Add("test2", DateTime.Now, "Tasks.txt");
            var tasks = taskManager.GetTask("Tasks.txt");
            var expectedResult = new[] { "1 test " + DateTime.Now.ToString("dd/MM/yy") + " ToDo", "2 test2 " + DateTime.Now.ToString("dd/MM/yy") + " ToDo" };
            CollectionAssert.AreEqual(tasks, expectedResult);
            taskManager.UpdateDate("2","17/11/16");
            var expectedResultAfterUpdate = new[] { "1 test " + DateTime.Now.ToString("dd/MM/yy") + " ToDo", "2 test2 17/11/16 ToDo" };
            CollectionAssert.AreEqual(stringTasks, expectedResultAfterUpdate);
        }
    }
}
