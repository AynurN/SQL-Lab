using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyDataManagement
{
    public static class SQLHelper
    {
        const string SqlConnectionString= "Server=WIN-S7KB46T76ET;Database=Academy_Data_Tables;Trusted_Connection=True;TrustServerCertificate=True";
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
        
        public static DataTable ReadAll(string com)
        {
            SQLconnection.Open();
            DataTable dataTable = new DataTable();
            using(SqlDataAdapter adapter= new SqlDataAdapter(com, SQLconnection))
            {
                adapter.Fill(dataTable);
            }

            SQLconnection.Close();
            return dataTable;
        }
     
            
        }

           

    }

