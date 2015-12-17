using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    class VerifierNameAndDescription
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

    public class VeifierDateAndDuDate
    {
        private string date;
        private string duDate;

        public VeifierDateAndDuDate(string date, string duDate)
        {
            this.date = date;
            this.duDate = duDate;
        }

        public VeifierDateAndDuDate(string date)
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

        public DateTime? VerifyDuTempDate()
        {
            DateTime tempDate;
            if (duDate == null)
                return null;
            if (!DateTime.TryParse(duDate, out tempDate))
            {
                tempDate = DateTime.Now;
                Console.WriteLine("The Date is invalid, will be set to the current day");
            }
            return tempDate;
        }

        public bool VerifyDuDate()
        {
            var dateTime = VerifyTempDate();
            var duDateTime = VerifyDuTempDate();
            if (duDateTime != null)
            {
                var timeSpan = duDateTime - dateTime;
                if (timeSpan == null) return false;
                var days = ((TimeSpan) timeSpan).TotalDays;
                if (!(days < 0)) return true;
                return false;
            }
            return true;
        }
    }
}

