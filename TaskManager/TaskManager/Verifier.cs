namespace TaskManager
{
    using System;

    public class VerifierNameAndDescription
    {
        private string name;
        private string description;

        public VerifierNameAndDescription(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public bool VerifyName()
        {
            return name != null;
        }

        public string VerifyDescription()
        {
            return description ?? null;
        }
    }

    public class VerifierFileAndStatus
    {
        private string status;
        private string fileName;

        public VerifierFileAndStatus(string fileName)
        {
            this.fileName = fileName;

        }

        public VerifierFileAndStatus(string fileName, string status)
        {
            this.fileName = fileName;
            this.status = status;
        }

        public string VerifyFileName()
        {
            return fileName ?? "Tasks.xml";
        }

        public string VerifyStatus()
        {
            return status ?? "Done";
        }
    }

    public class VerifierDateAndDueDate
    {
        private string date;
        private string dueDate;

        public VerifierDateAndDueDate(string date, string dueDate)
        {
            this.date = date;
            this.dueDate = dueDate;
        }

        public VerifierDateAndDueDate(string date)
        {
            this.date = date;
        }

        public DateTime VerifyTempDate()
        {
            DateTime tempDate;
            if (date == null)
            {
                tempDate = DateTime.Now;
                return tempDate;
            }
            if (!DateTime.TryParse(date, out tempDate))
            {
                tempDate = DateTime.Now;
                Console.WriteLine("The Date is invalid, will be set to the current day");
            }
            return tempDate;
        }

        public DateTime? VerifyDueTempDate()
        {
            DateTime tempDate;
            if (dueDate == null)
                return null;
            if (!DateTime.TryParse(dueDate, out tempDate))
            {
                tempDate = DateTime.Now;
                //Console.WriteLine("The Date is invalid, will be set to the current day");
            }
            return tempDate;
        }

        public bool VerifyDueDate()
        {
            var dateTime = VerifyTempDate();
            if (dueDate != null)
            {
                DateTime dueDateTime;
                if (!DateTime.TryParse(dueDate, out dueDateTime))
                {
                    dueDateTime = DateTime.Now;
                    Console.WriteLine("The Date is invalid, will be set to the current day");
                }
                var timeSpan = dueDateTime - dateTime;
                var days = timeSpan.TotalDays;
                return !(days < 0);
            }
            return true;
        }
    }
}

