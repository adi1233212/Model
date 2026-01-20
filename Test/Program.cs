using Model;
using ViewModel;
namespace Test

{
    internal class Program
    {
        static void Main(string[] args)
        {
            CityDB cdb = new();
            CityList cList = cdb.SelectAll();
            foreach(City c in cList)
                Console.WriteLine(c.CityName);

            PersonDB personDB = new ();
            PersonList pList = personDB.SelectAll();
            foreach (Person p in pList)
                Console.WriteLine(p.FirstName);

            StudentDB studentDB = new();
            StudentList sList = studentDB.SelectAll();
            foreach (Student s in sList)
                Console.WriteLine(s.Tel);

            TeacherDB teacherDB = new();
            TeacherList tList = teacherDB.SelectAll();
            foreach (Teacher t in tList)
            {
                Console.WriteLine(t.FirstName);
                Console.WriteLine(t.IsEducator);
                Console.WriteLine(t.StartWorkingDate);

            }


        }
    }
}
