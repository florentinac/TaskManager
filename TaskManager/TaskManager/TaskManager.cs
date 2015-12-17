namespace TaskManager
{
    using System;
    using System.Collections.Generic;

    public class TaskManager
    {
        private List<Task> tasks = new List<Task>();

        public void Add(string taskName, string description, string txtDate, string txtDueDate, string fileName, string category)
        {
            var validateNameAndDescr = new VerifierNameAndDescription(taskName, description);
            if (!validateNameAndDescr.VerifyName())
                return;
            var validateDateAndDuDate = new VerifierDateAndDueDate(txtDate, txtDueDate);
            var tempDate = validateDateAndDuDate.VerifyTempDate();
            var dueDate = validateDateAndDuDate.VerifyDueDate();
            if (dueDate)
            {
                var tempDueDate = validateDateAndDuDate.VerifyDueTempDate();
                var validateFileAndStatus = new VerifierFileAndStatus(fileName);
                var newTask = new Task(taskName, validateNameAndDescr.VerifyDescription(), tempDate, tempDueDate,
                    GlobalConstants.ToDo, category);
                tasks.Add(newTask);
                var service = new TaskService(validateFileAndStatus.VerifyFileName());
                service.AddTask(newTask);
                Console.WriteLine("The task was successfuly added");
            }
            else
                Console.WriteLine("Date cannot be greater then DuDate");
        }
        public void GetTask(string fileName)
        {
            var validateFileName = new VerifierFileAndStatus(fileName);
            fileName = validateFileName.VerifyFileName();
            var xml = new Repository(fileName);
            xml.GetTasks();
        }

        public void UpdateStatus(string id, string status, string fileName)
        {
            var validateFileAndStatus = new VerifierFileAndStatus(fileName, status);
            status = validateFileAndStatus.VerifyStatus();
            fileName = validateFileAndStatus.VerifyFileName();
            var xml = new Repository(fileName);
            xml.UpdateStatus(id, status);
        }

        public void UpdateDate(string id, string date, string fileName)
        {
            var validateFileAndStatus = new VerifierFileAndStatus(fileName);
            fileName = validateFileAndStatus.VerifyFileName();
            var validateDateAndDuDate = new VerifierDateAndDueDate(date);
            var tempdate = validateDateAndDuDate.VerifyTempDate();
            var xml = new Repository(fileName);
            xml.UpdateDate(id, tempdate);
        }

        public void SortAscending(string fileName, string sortBy)
        {
            var validateFileAndStatus = new VerifierFileAndStatus(fileName);
            fileName = validateFileAndStatus.VerifyFileName();
            var view = new TaskView(fileName);            
            view.SortAsc(sortBy);
        }

        public void SortDescending(string fileName, string sortBy)
        {
            var validateFileAndStatus = new VerifierFileAndStatus(fileName);
            fileName = validateFileAndStatus.VerifyFileName();
            var view= new TaskView(fileName);
            view.SortDesc(sortBy);
        }

        public void GetTaskByCategory(string fileName, string category)
        {
            var validateFileAndStatus = new VerifierFileAndStatus(fileName);
            fileName = validateFileAndStatus.VerifyFileName();
            var view = new TaskView(fileName);
            view.ViewTaskByCategory(category);
        }

        public void Search(string word, string fileName)
        {
            var validateFileAndStatus = new VerifierFileAndStatus(fileName);
            fileName = validateFileAndStatus.VerifyFileName();
            var view = new TaskView(fileName);
            view.ViewTaskMatch(word);
        }
    }
}
