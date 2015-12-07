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
            var main = new MainResponsability();
            if (args.Length <= 0)
            {
                Console.Write("The syntax of this product is:" +
                              "\r\nADD: Add new task and save in a file" +
                              "\r\n     --message:  Specifiy the task to be added" +
                              "\r\n     --date: Specifiy or not the date for task, the format for date is: dd-MM-yyyy" +
                              "\r\n     --fileName: Specifiy or not the file for save the Tasks" +
                              "\r\nGET: Get the existents Tasks" +
                              "\r\n     --fileName: Specify the fileName where are the Tasks" +
                              "\r\nUPDATE: Update the Task with new status"+
                              "\r\n     --id: Specifiy the task id"+
                              "\r\n          --status: Update status from ToDo to Done" +
                              "\r\n          --date: Change Due Date, format for date dd-MM-yyyy");

                Console.WriteLine(" ");
            }
            else if (args[0].Equals("add"))
            {
                main.AddNewTask(args);
            }
            else if (args[0].Equals("get"))
            {
                main.GetTask(args);
            }
            else if (args[0].Equals("update"))
            {
                main.UpdateTask(args);
            }
            else
            {
                Console.WriteLine("Insert one Optione(add/get/update)");
            }

        }
               
    }
}
