using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public class DataBaseConnection
    {
        public void DBConnection()
        {
            SqlConnection cnn;
            string connetionString =
                @"Data Source=tcp:192.168.97.22\SQLEXPRESS,1433;Initial Catalog=TaskManager;User ID=sa;Password=12345xx**";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                Console.WriteLine("Connection Open ! ");
                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not open connection ! " + ex.Message);
            } 
        }
        
        
    }
}
