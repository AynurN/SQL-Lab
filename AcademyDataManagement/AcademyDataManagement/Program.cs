namespace AcademyDataManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student() { Name = "Aynur", Surname = "Nazarli", Age = 20, Grant=200, GroupId=1 };
            Student student2 = new Student() { Name = "AYten", Surname = "Babayeva", Age = 21, Grant = 300,GroupId=1 };
            IStudentSQLService studentSQLService = new StudentSQLService();
            //studentSQLService.Insert(student);
            //studentSQLService.Insert(student2);
            //studentSQLService.Delete(2);
            //studentSQLService.GetData(1);
            //Console.WriteLine(studentSQLService.GetData(1));
            foreach (var item in studentSQLService.GetAllDatas())
            {
                Console.WriteLine(item);


            }

        }
    }
}
