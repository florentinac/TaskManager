using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace TaskManager
{
    public class ValidatorNameAndDescrition
    {
        private string name;
        private string description;

        public ValidatorNameAndDescrition(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public bool ValidateName()
        {
            return name != null;
        }

        public string ValidateDescripion()
        {
            return description ?? null;
        }
    }

    public class ValidatorFileAndStatus
    {
        private string status;
        private string fileName;

        public ValidatorFileAndStatus(string fileName)
        {
            this.fileName = fileName;
           
        }

        public ValidatorFileAndStatus(string fileName,string status)
        {
            this.fileName = fileName;
            this.status = status;
        }

        public string FileName()
        {
            return fileName ?? "Tasks.xml";
        }

        public string Status()
        {
            return status ?? "Done";

        }
    }

    public class ValidatorDateAndDuDate
    {
        private string date;
        private string duDate;

        public ValidatorDateAndDuDate(string date, string duDate)
        {
            this.date = date;
            this.duDate = duDate;
        }

        public ValidatorDateAndDuDate(string date)
        {
            this.date = date;
        }

        public DateTime TempDate()
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

        internal DateTime? DuTempDate()
        {
            if (duDate == null)
                return null;

            return TempDate();
        }

        internal static bool DuDate(DateTime? duDate, DateTime date)
        {
            var timeSpan = duDate - date;
            if (timeSpan == null) return false;
            var difference = (TimeSpan)timeSpan;
            var days = difference.TotalDays;
            if (!(days < 0)) return true;
            Console.WriteLine("Date cannot be greater then DuDate");
            return false;
        }
    }
}
