using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace TaskManager.Tests
{
    [TestClass]
    public class VerifierTests
    {
        [TestMethod]
        public void ShouldHaveADefaultFileNameForSaveTask()
        {
            var validateFileName = new VerifierFileAndStatus(null);
            var fileName = validateFileName.VerifyFileName();
            Assert.AreEqual("Tasks.xml", fileName);
        }

        [TestMethod]
        public void ShouldSuportSpecifiedAFileNameForSaveTask()
        {
            var validateFileName = new VerifierFileAndStatus("FileNameTest.xml");
            var fileName = validateFileName.VerifyFileName();
            Assert.AreEqual("FileNameTest.xml", fileName);
        }

        [TestMethod]
        public void ShouldNotSupportAddANewTaskWithoutTaskTitle()
        {
            var validateTaskTitle = new VerifierNameAndDescription(null, null);
            var taskTitle = validateTaskTitle.VerifyName();
            taskTitle.ShouldBeFalse();
        }

        [TestMethod]
        public void ShouldSupportAddANewTaskWithSpecifiedTitle()
        {
            var validateTaskTitle = new VerifierNameAndDescription("Go to work", null);
            var taskTitle = validateTaskTitle.VerifyName();
            taskTitle.ShouldBeTrue();
        }

        [TestMethod]
        public void ShouldSupportAddANewTaskWithoutDescription()
        {
            var validateTaskTitle = new VerifierNameAndDescription("Go to work", null);
            var taskDescription = validateTaskTitle.VerifyDescription();
            Assert.AreEqual(null, taskDescription);
        }

        [TestMethod]
        public void ShouldSupportAddANewTaskWithDescription()
        {
            var validateTaskTitle = new VerifierNameAndDescription("Go to work", "something to do");
            var taskDescription = validateTaskTitle.VerifyDescription();
            Assert.AreEqual("something to do", taskDescription);
        }

        [TestMethod]
        public void ShouldSupportADefalutDateForTask()
        {
            var validateDate = new VerifierDateAndDueDate(null);
            var taskDate = validateDate.VerifyTempDate();
            Assert.AreEqual(DateTime.Now.Date, taskDate.Date);
        }

        [TestMethod]
        public void ShouldSupportASpecifiedDateForTask()
        {
            var validateDate = new VerifierDateAndDueDate("10-11-2015");
            var expectedresult = new DateTime(2015, 10, 11, 00, 00, 00);
            expectedresult.ToString("tt", CultureInfo.InvariantCulture);
            var taskDate = validateDate.VerifyTempDate();
            Assert.AreEqual(expectedresult, taskDate.Date);
        }

        [TestMethod]
        public void ShouldNotSupportAddAInvalidDateTimeForTaskAndShouldReplaceWithCurrentDateTime()
        {
            var validateDate = new VerifierDateAndDueDate("34-45-2015");
            var expectedresult = DateTime.Today.Date;
            expectedresult.ToString("tt", CultureInfo.InvariantCulture);
            var taskDate = validateDate.VerifyTempDate();
            Assert.AreEqual(expectedresult, taskDate.Date);
        }

        [TestMethod]
        public void ShouldSupportAddANewTAskWithoutDuDate()
        {
            var validateDate = new VerifierDateAndDueDate(null, null);
            var taskDuDate = validateDate.VerifyDueTempDate();
            Assert.AreEqual(null, taskDuDate);
        }

        [TestMethod]
        public void ShouldNotSupportAddANewTaskWithDuDateLessThenDate()
        {
            var validateDate = new VerifierDateAndDueDate("10-11-2015", "9-10-2015");
            var taskDuDate = validateDate.VerifyDueDate();
            taskDuDate.ShouldBeFalse();
        }

        [TestMethod]
        public void ShouldSupportAddANewTaskWithDuDateGreaterThenDate()
        {
            var validateDate = new VerifierDateAndDueDate("10-11-2015", "11-11-2015");
            var taskDuDate = validateDate.VerifyDueDate();
            taskDuDate.ShouldBeTrue();
        }

        [TestMethod]
        public void ShouldSupportUpdateATaskWithDefaultStatus()
        {
            var validateStatus = new VerifierFileAndStatus(null, null);
            var taskStatus = validateStatus.VerifyStatus();
            Assert.AreEqual("Done", taskStatus);
        }

        [TestMethod]
        public void ShouldSupportUpdateATaskWithSpecifiedStatus()
        {
            var validateStatus = new VerifierFileAndStatus(null, "InProgress");
            var taskStatus = validateStatus.VerifyStatus();
            Assert.AreEqual("InProgress", taskStatus);
        }
    }
}
