using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    class Validator
    {
        public bool Validate(string TaskName)
        {            
            return TaskName != null;
        }

        public static DateTime TempDate(string date)
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

        public static string FileName(string fileName)
        {
            return fileName ?? "Tasks.txt";
        }

        public static string Status(string status)
        {
            return status ?? "Done";

        }

        internal static DateTime? DuTempDate(string txtDuDate)
        {
            if (txtDuDate == null)
                return null;
             
            return TempDate(txtDuDate);
        }

        internal static bool DuDate(DateTime? duDate, DateTime addTaskDate)
        {
            var timeSpan = duDate - addTaskDate;
            if (timeSpan == null) return false;
            var difference = (TimeSpan)timeSpan;
            var days = difference.TotalDays;
            if (!(days < 0)) return true;
            Console.WriteLine("Date cannot be greater then DuDate");
            return false;
        }
    }
    

}
