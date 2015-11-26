using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager_Method;

namespace TaskManager
{
    class TaskManagerMain
    {
        static void Main(string[] args)
        {
            var taskManager = new TaskManager_Methods();
            taskManager.Add(args[0]);
            Console.WriteLine(taskManager);
        }
    }
}
