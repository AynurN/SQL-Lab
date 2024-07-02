using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyDataManagement
{
    public static class SQLHelper
    {
        const string SqlConnectionString= "Server=SIRIUS05;Database=Academy_Data;Trusted_Connection=True;";
        static SqlConnection _sqlConnection = null;
        public static SqlConnection SQLconnection {
            get { if (_sqlConnection == null)
                    _sqlConnection = new SqlConnection(SqlConnectionString);
                    return _sqlConnection; }
                
                }
        public static int Execute(string command)
        {
            SQLconnection.Open();
            SqlCommand cmd = new SqlCommand(command, SQLconnection);
           int check= cmd.ExecuteNonQuery();
            if(check > 0)
            {
                Console.WriteLine("Executed");
            }
            else
            {
                Console.WriteLine("Error");
            }
            SQLconnection.Close();
            return check;
        }
        

    }
}
