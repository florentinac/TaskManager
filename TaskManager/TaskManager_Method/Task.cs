using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    class Task
    {
        public enum Status
        {
            ToDo,
            Done
        }

        private string taskName;
        private DateTime date;
        private Status status;
        private int id; 

        public Task()
        {
        }

        public Task(int id, string taskName, DateTime date, Status status)
        {
            this.id = id;
            this.taskName = taskName;
            this.date = date;
            this.status = status;
        }

        public string GetName => taskName;
        //public string GetDate => date.ToString("dd/MM/yy");
        public string GetStatus => status.ToString();
        public int GetId => id;
    }
}
