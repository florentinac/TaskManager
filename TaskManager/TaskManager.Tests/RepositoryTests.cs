using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace TaskManager.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void IsShouldSuportAddANewTask()
        {
            var task = new Task("Title", "ceva", DateTime.Now, DateTime.Today, "", "home");
            var repository = new MockRepository();
            repository.AddTask(task);
            repository.ShouldNotBeNull();
        }
    }
}
