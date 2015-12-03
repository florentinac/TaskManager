using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManager;

namespace TaskManager
{
    class TaskManagerMain
    {
        static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                Console.Write("The syntax of this product is:" +
                              "\r\nADD: Add new task and save in a file" +
                              "\r\n     --message:  Specifiy the task to be added" +
                              "\r\n     --date: Specifiy the date for task" +
                              "\r\nGET: Get the existents Tasks" +
                              "\r\n     --fileName: Specify the fileName where is the Tasks" +
                              "\r\nUPDATE: Update the Task with new status"+
                              "\r\n     --id: Specifiy the task id");
                Console.WriteLine(" ");
            }
            else
            {
                //var taskManager = new TaskFunctionality();
                var main = new MainResponsability();
                main.AddNewTask(args);
                main.GetTask(args);
                main.UpdateTask(args);
            }
        }          
    }
}
