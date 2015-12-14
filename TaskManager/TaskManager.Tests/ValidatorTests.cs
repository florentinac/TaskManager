using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace TaskManager.Tests
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void ShouldHaveADefaultFileNameForSaveTask()
        {
            var validateFileName = new ValidatorFileAndStatus(null);
            var fileName = validateFileName.FileName();
            Assert.AreEqual("Tasks.xml", fileName);
        }

        [TestMethod]
        public void ShouldSuportSpecifiedAFileNameForSaveTask()
        {
            var validateFileName = new ValidatorFileAndStatus("FileNameTest.xml");
            var fileName = validateFileName.FileName();
            Assert.AreEqual("FileNameTest.xml", fileName);
        }

        [TestMethod]
        public void ShouldNotSupportAddANewTaskWithoutTaskTitle()
        {
            var validateTaskTitle = new ValidatorNameAndDescrition(null,null);
            var taskTitle = validateTaskTitle.ValidateName();
            taskTitle.ShouldBeFalse();
        }

        [TestMethod]
        public void ShouldSupportAddANewTaskWithSpecifiedTitle()
        {
            var validateTaskTitle = new ValidatorNameAndDescrition("Go to work", null);
            var taskTitle = validateTaskTitle.ValidateName();
            taskTitle.ShouldBeTrue();
        }

        [TestMethod]
        public void ShouldSupportAddANewTaskWithoutDescription()
        {
            var validateTaskTitle = new ValidatorNameAndDescrition("Go to work", null);
            var taskDescription = validateTaskTitle.ValidateDescripion();
            Assert.AreEqual(null,taskDescription);
        }

        [TestMethod]
        public void ShouldSupportAddANewTaskWithDescription()
        {
            var validateTaskTitle = new ValidatorNameAndDescrition("Go to work", "something to do");
            var taskDescription = validateTaskTitle.ValidateDescripion();
            Assert.AreEqual("something to do", taskDescription);
        }

        [TestMethod]
        public void ShouldSupportADefalutDateForTask()
        {
            var validateDate = new ValidatorDateAndDuDate(null);
            var taskDate = validateDate.TempDate();
            Assert.AreEqual(DateTime.Now.Date, taskDate.Date);
        }

        [TestMethod]
        public void ShouldSupportASpecifiedDateForTask()
        {
            var validateDate = new ValidatorDateAndDuDate("10-11-2015");
            var expectedresult = new DateTime(2015, 10, 11, 00, 00, 00);
            expectedresult.ToString("tt", CultureInfo.InvariantCulture);
            var taskDate = validateDate.TempDate();
            Assert.AreEqual(expectedresult, taskDate.Date);
        }

        [TestMethod]
        public void ShouldNotSupportAddAInvalidDateTimeForTaskAndShouldReplaceWithCurrentDateTime()
        {
            var validateDate = new ValidatorDateAndDuDate("34-45-2015");
            var expectedresult = new DateTime(2015, 12, 14, 00, 00, 00);
            expectedresult.ToString("tt", CultureInfo.InvariantCulture);
            var taskDate = validateDate.TempDate();
            Assert.AreEqual(expectedresult, taskDate.Date);
        }

        [TestMethod]
        public void ShouldSupportAddANewTAskWithoutDuDate()
        {
            var validateDate = new ValidatorDateAndDuDate(null,null);
            var taskDuDate = validateDate.DuTempDate();
            Assert.AreEqual(null, taskDuDate);
        }

        [TestMethod]
        public void ShouldNotSupportAddANewTaskWithDuDateLessThenDate()
        {
            var validateDate = new ValidatorDateAndDuDate("10-11-2015", "9-10-2015");
            var taskDuDate = validateDate.DuDate();
            taskDuDate.ShouldBeFalse();
        }

        [TestMethod]
        public void ShouldSupportAddANewTaskWithDuDateGreaterThenDate()
        {
            var validateDate = new ValidatorDateAndDuDate("10-11-2015", "11-11-2015");
            var taskDuDate = validateDate.DuDate();
            taskDuDate.ShouldBeTrue();
        }

        [TestMethod]
        public void ShouldSupportUpdateATaskWithDefaultStatus()
        {
            var validateStatus = new ValidatorFileAndStatus(null,null);
            var taskStatus = validateStatus.Status();
            Assert.AreEqual("Done",taskStatus);
        }

        [TestMethod]
        public void ShouldSupportUpdateATaskWithSpecifiedStatus()
        {
            var validateStatus = new ValidatorFileAndStatus(null, "InProgress");
            var taskStatus = validateStatus.Status();
            Assert.AreEqual("InProgress", taskStatus);
        }



    }
}
