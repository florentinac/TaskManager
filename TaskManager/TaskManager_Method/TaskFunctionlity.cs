namespace TaskManager
{
    using TaskManager_Method;
    using System;
    using System.Collections.Generic;

    public class TaskFunctionality
    {
        private List<Task> tasks = new List<Task>();                      

        public TaskFunctionality()
        {
            //fileWrite = new ClassIFileWriter();
        }

        public TaskFunctionality(IFileWrite fileWrite)
        {
            //this.fileWrite = fileWrite;
        }

        public void Add(string taskName, string description, string txtDate, string txtDuDate, string fileName)
        {
            var validateNameAndDescr = new ValidatorNameAndDescrition(taskName,description);
            if (!validateNameAndDescr.ValidateName())
                return;
            var validateDateAndDuDate = new ValidatorDateAndDuDate(txtDate,txtDuDate);
            var tempDate = validateDateAndDuDate.TempDate();
            var duDate = validateDateAndDuDate.DuDate();
            if (duDate)
            {
                var tempDuDate = validateDateAndDuDate.DuTempDate(); 
                var validateFileAndStatus = new ValidatorFileAndStatus(fileName);
                var newTask = new Task(taskName, validateNameAndDescr.ValidateDescripion(), tempDate, tempDuDate,
                    Task.Status.ToDo);
                tasks.Add(newTask);
                Task.StatusSaveTask(validateFileAndStatus.FileName(), newTask);
                Console.WriteLine("The task was successfuly added");
            }
            else 
                Console.WriteLine("Date cannot be greater then DuDate");
        }             

        public void GetTask(string fileName)
        {           
            var validateFileName = new ValidatorFileAndStatus(fileName);
            fileName = validateFileName.FileName();
            var xml = new CreateXMLDoc(fileName);
            xml.ReadTasks();
        }

        public void UpdateStatus(string id, string status, string fileName)
        {
            var validateFileAndStatus = new ValidatorFileAndStatus(status, fileName);
            status = validateFileAndStatus.Status();
            fileName = validateFileAndStatus.FileName();
            var xml = new CreateXMLDoc(fileName);
            xml.UpdateStatus(id, status);                  
        }
              
        public void UpdateDate(string id, string date, string fileName)
        {
            var validateFileAndStatus = new ValidatorFileAndStatus(fileName);
            fileName = validateFileAndStatus.FileName();
            var validateDateAndDuDate = new ValidatorDateAndDuDate(date);
            var tempdate = validateDateAndDuDate.TempDate();
            var xml = new CreateXMLDoc(fileName);
            xml.UpdateDate(id, tempdate);
        }

        public void SortAscending(string fileName, string sortBy)
        {
            var validateFileAndStatus = new ValidatorFileAndStatus(fileName);
            fileName = validateFileAndStatus.FileName();
            var xmlSorted = new TasksSorted(fileName);
            xmlSorted.SortAsc(sortBy);     
        }

        public void SortDescending(string fileName, string sortBy)
        {
            var validateFileAndStatus = new ValidatorFileAndStatus(fileName);
            fileName = validateFileAndStatus.FileName();
            var xmlSorted = new TasksSorted(fileName);
            xmlSorted.SortDesc(sortBy);
        }      

        public void Search(string word, string fileName)
        {
            var validateFileAndStatus = new ValidatorFileAndStatus(fileName);
            fileName = validateFileAndStatus.FileName();
            var taskMatch = new SearchTask(fileName);
            taskMatch.SearchTaskMatch(word);           
        }
    }

   

}
