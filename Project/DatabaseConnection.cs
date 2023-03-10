using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class DatabaseConnection
    {
       
           static string server = "localhost";
           static string database = "Project";
           static string username = "root";
           static string password = "";

           public static string conString = "server=" + server + ";" + "database=" + database + ";" + "uid=" + username + ";" + "password=" + password + ";";
          
          
         
        
          

       
       

        
    }
}
