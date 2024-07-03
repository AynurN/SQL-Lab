using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyDataManagement
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public decimal Grant { get; set; }
        public int? GroupId { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}, FulName:{Name+" "+Surname }, Age: {Age}, Grant: {Grant}, GroupId: {GroupId}";
        }

    }
}
