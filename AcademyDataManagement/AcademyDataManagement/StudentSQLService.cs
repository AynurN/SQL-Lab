using System;
using System.Collections.Generic;
using System.Data;
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

        public List<Student> GetAllDatas()
        {
            List<Student> students = new List<Student>();
            DataTable datas = SQLHelper.ReadAll("select * from Students");
            foreach (DataRow item in datas.Rows)
            {
                students.Add(new Student() { Id = (int)item[0], Name = (string)item[1], Surname = (string)item[2], Age = (int)item[3], Grant = (decimal)item[4], GroupId = (int)item[5] });
                
            }
            return students;
        }

        public Student GetData(int id)
        {
            DataTable data = SQLHelper.ReadAll($"select * from Students where Id={id}");
            DataRow row = data.Rows[0];
            Student student = new Student() { Id = (int)row[0], Name = (string)row[1], Surname = (string)row[2], Age = (int)row[3], Grant = (decimal)row[4], GroupId = (int)row[5] };
            return student;
        }

        public void Insert(Student student)
        {
            int result = SQLHelper.Execute($"insert into Students values ('{student.Name}', '{student.Surname}',{student.Age}, {student.Grant},{student?.GroupId})");
            if (result > 0)
                Console.WriteLine("Inserted!");
            else Console.WriteLine("Could not insert!");
        }

        public void Update(int id, string colName, string newValue)
        {
            int result=SQLHelper.Execute($"update Students set {colName}={(colName=="Grant"? decimal.Parse(newValue) : $"'{newValue}'")} where Id={id}");
           if(result>0)
                Console.WriteLine("updated");
           else
                Console.WriteLine("Error!");
        }
    }
}
