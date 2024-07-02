using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyDataManagement
{
    public class StudentSQLService : IStudentSQLService
    {
        
        public void Delete(int id)
        {
            int result = SQLHelper.Execute($"delete from Students where id={id}");
            if (result > 0)
                Console.WriteLine("Deleted!");
            else Console.WriteLine("Could not delete");

        }

        public void GetAllDatas()
        {
            
        }

        public void GetData(int id)
        {
           
        }

        public void Insert(Student student)
        {
            int result = SQLHelper.Execute($"insert into Students values ({student.Name}, {student.Surname},{student.Age}, {student.Grant})");
            if (result > 0)
                Console.WriteLine("Inserted!");
            else Console.WriteLine("Could not insert!");
        }

        public void Update(int id, string command, string newData)
        {
            
           
        }
    }
}
