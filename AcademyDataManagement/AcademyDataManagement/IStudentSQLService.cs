using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyDataManagement
{
    public interface IStudentSQLService
    {
        void GetData(int id);
        void GetAllDatas();
        void Insert(Student student);
        void Delete(int id);
        void Update(int id, string command, string newData);
    }
}
