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
            taskManager.Add("test", "", "","","");       
            //taskManager.Count.ShouldEqual(1);
        }      

        [TestMethod]
        public void TestCountWhenAddTwoTask()
        {
            var stringTasks = new ClassIStringTasks();
            var taskManager = new TaskFunctionality(stringTasks);       
            taskManager.Add("test", "","10-12-2013","", "");
            taskManager.Add("test2", "","10-12-2013","", "");
            //taskManager.Count.ShouldEqual(2);
        }

        [TestMethod]
        public void TestAddToASpecifiedFile()
        {
            var stringTasks = new ClassIStringTasks();
            var taskManager = new TaskFunctionality(stringTasks);
            taskManager.Add("test","", "","", "TestAdd.txt");
            //taskManager.Count.ShouldEqual(1);
        }

        [TestMethod]
        public void TestAddTaskWithMultiplayLines()
        {
            var stringTasks = new ClassIStringTasks();
            var taskManager = new TaskFunctionality(stringTasks);
            taskManager.Add("\r\nFirst line." + "\r\nSecondLine" + "\r\nThirdLine","","", "", "TestAdd.txt");
            taskManager.Add("NewTask","","", "", "TestAdd.txt");
            //taskManager.Count.ShouldEqual(2);
        }

        [TestMethod]
        public void TestAddTaskWithInValidDateTime()
        {
            var stringTasks = new ClassIStringTasks();
            var taskManager = new TaskFunctionality(stringTasks);
            taskManager.Add("test", "","11/56/2014","", "TestAdd.txt");
            var expectedresult = new[] { "1 test " + DateTime.Now.ToString("d") + " ToDo" };
            taskManager.GetTask("Tasks.txt");
            //taskManager.Count.ShouldEqual(1);
            //CollectionAssert.AreEqual(tasks, expectedresult);
        }

        [TestMethod]
        public void TestGetTaskWithDefaultDateTime()
        {
            var stringTasks = new ClassIStringTasks();
            var taskManager = new TaskFunctionality(stringTasks);
            taskManager.Add("test","","", "", "");
            var expectedresult = new[] {"1 test " + DateTime.Now.ToString("d") + " ToDo"};
            //var tasks = taskManager.GetTask("TAsks.txt");
            //taskManager.Count.ShouldEqual(1);
            //CollectionAssert.AreEqual(tasks,expectedresult);
        }       

        [TestMethod]
        public void TestGetTaskWithASpecificateDateTime()
        {
            var stringTasks = new ClassIStringTasks();
            var taskManager = new TaskFunctionality(stringTasks);
            taskManager.Add("test","", "12/24/2015","", "");
            var expectedresult = new[] { "1 test 12/24/2015 ToDo" };
            //var tasks = taskManager.GetTask("Tasks.txt");
            //taskManager.Count.ShouldEqual(1);
            //CollectionAssert.AreEqual(tasks, expectedresult);
        }
        [TestMethod]
        public void TestGetFromDefaultFile()
        {
            var stringTasks = new ClassIStringTasks();
            var taskManager = new TaskFunctionality(stringTasks);
            taskManager.Add("test","", "12/24/2015","", "");
            var expectedresult = new[] { "1 test 12/24/2015 ToDo" };
            //var tasks = taskManager.GetTask("");
            //taskManager.Count.ShouldEqual(1);
            //CollectionAssert.AreEqual(tasks, expectedresult);
        }

        [TestMethod]
        public void TestGetTaskWhenAddTwoTasks()
        {          
            var stringTasks = new ClassIStringTasks();           
            var taskManager = new TaskFunctionality(stringTasks);
            taskManager.Add("test", "",DateTime.Now.ToString("d"),"", "");
            taskManager.Add("test2", "",DateTime.Now.ToString("d"),"", "");
           // var tasks = taskManager.GetTask("");
            var expectedResult = new[] {"1 test " + DateTime.Now.ToString("d") + " ToDo", "2 test2 " + DateTime.Now.ToString("d") + " ToDo"};
            //CollectionAssert.AreEqual(tasks,expectedResult);          
        }

        [TestMethod]
        public void TestUpdateStatusTasks()
        {
            var stringTasks = new ClassIStringTasks();
            var taskManager = new TaskFunctionality(stringTasks);
            taskManager.Add("test","", DateTime.Now.ToString("d"),"", "");
            taskManager.Add("test2", "",DateTime.Now.ToString("d"),"", "");
            //var tasks = taskManager.GetTask("");
            var expectedResult = new[] {"1 test " + DateTime.Now.ToString("d") + " ToDo","2 test2 " + DateTime.Now.ToString("d") + " ToDo" };
            //CollectionAssert.AreEqual(tasks, expectedResult);
            taskManager.UpdateStatus("1", "Done", "Tasks.txt");
            var expectedResultAfterUpdate = new[] {"[NewTask]" + " " + "1 test " + DateTime.Now.ToString("d") + " Done", "[NewTask]" + " " + "2 test2 " + DateTime.Now.ToString("d") + " ToDo" };
            CollectionAssert.AreEqual(stringTasks, expectedResultAfterUpdate);
        }

        [TestMethod]
        public void TestUpdateDateTasks()
        {
            var stringTasks = new ClassIStringTasks();
            var taskManager = new TaskFunctionality(stringTasks);
            taskManager.Add("test","", DateTime.Now.ToString("d"),"", "");
            taskManager.Add("test2","", DateTime.Now.ToString("d"),"", "");
            //var tasks = taskManager.GetTask("");
            var expectedResult = new[] { "1 test " + DateTime.Now.ToString("d") + " ToDo", "2 test2 " + DateTime.Now.ToString("d") + " ToDo" };
            //CollectionAssert.AreEqual(tasks, expectedResult);
            taskManager.UpdateDate("2","11/17/16","");
            var expectedResultAfterUpdate = new[] { "[NewTask]" + " " + "1 test " + DateTime.Now.ToString("d") + " ToDo", "[NewTask]" + " " + "2 test2 17/11/16 ToDo" };
            CollectionAssert.AreEqual(stringTasks, expectedResultAfterUpdate);
        }

        //[TestMethod]
        //public void TestGetAscendingDateTasks()
        //{
        //    var stringTasks = new ClassIStringTasks();
        //    var taskManager = new TaskFunctionality(stringTasks);           
        //    taskManager.Add("test","", DateTime.Now.ToString("d"),"", "");
        //    taskManager.Add("test2","", "11/17/15", "","");
        //    //var tasks = taskManager.GetTask("");
        //    var expectedResult = new[] { "1 test " + DateTime.Now.ToString("d") + " ToDo", "2 test2 11/17/2015 ToDo", };
        //    //CollectionAssert.AreEqual(tasks, expectedResult);
        //    taskManager.SortAscending("Tasks.txt");
        //    var sortTasksResult = new[] {"2 test2 11/17/2015 ToDo", "1 test " + DateTime.Now.ToString("d") + " ToDo" };
        //    CollectionAssert.AreEqual(stringTasks, sortTasksResult);
        //}

        //[TestMethod]
        //public void TestGetDescendingDateTasks()
        //{
        //    var stringTasks = new ClassIStringTasks();
        //    var taskManager = new TaskFunctionality(stringTasks);
        //    taskManager.Add("test", "",DateTime.Now.ToString("d"),"", "");
        //    taskManager.Add("test2", "","1/17/15","", "");
        //    //var tasks = taskManager.GetTask("");
        //    var expectedResult = new[] { "1 test " + DateTime.Now.ToString("d") + " ToDo", "2 test2 11/17/2015 ToDo"};
        //    //.AreEqual(tasks, expectedResult);
        //    taskManager.SortDescending("Tasks.txt");
        //    var sortTasksResult = new[] { "1 test " + DateTime.Now.ToString("d") + " ToDo", "2 test2 11/17/2015 ToDo"};
        //    CollectionAssert.AreEqual(stringTasks, sortTasksResult);
        //}
    }
}
