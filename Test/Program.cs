using Model;
using ViewModel;
namespace Test

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------CityDB-----");
            CityDB cdb = new();
            CityList cList = cdb.SelectAll();
            foreach(City c in cList)
                Console.WriteLine(c.CityName);

            Console.WriteLine("------PersonDB-----");

            PersonDB personDB = new ();
            PersonList pList = personDB.SelectAll();
            foreach (Person p in pList)
                Console.WriteLine(p.FirstName);

            Console.WriteLine("------StudentDB-----");
            StudentDB studentDB = new();
            StudentList sList = studentDB.SelectAll();
            foreach (Student s in sList)
                Console.WriteLine(s.Tel);

            Console.WriteLine("------TeacherDB-----");
            TeacherDB teacherDB = new();
            TeacherList tList = teacherDB.SelectAll();
            foreach (Teacher t in tList)
            {
                Console.WriteLine(t.FirstName);
                Console.WriteLine(t.IsEducator);
                Console.WriteLine(t.StartWorkingDate);

            }

            Console.WriteLine("------TeacherForStudentDB-----");
            TeacherForStudentDB teacherforstudentDB = new();
            TeacherForStudentList tsList = teacherforstudentDB.SelectAll();
            foreach (TeacherForStudent ts in tsList)
            {
                Console.WriteLine("the Teacher: " + ts.Teach.FirstName + " " + ts.Teach.LastName);
                Console.WriteLine("the Student: " + ts.Stu.FirstName + " " + ts.Stu.LastName);
            }


        }
    }
}
