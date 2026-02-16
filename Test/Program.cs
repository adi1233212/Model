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
            City cityToUpdate = cList[0];
            cityToUpdate.CityName += "xxx";
            cdb.Update(cityToUpdate);
            int x = cdb.SaveChanges();
            Console.WriteLine($"{x} rows were updated");

            Console.WriteLine("------PersonDB-----");
            PersonDB personDB = new ();
            PersonList pList = personDB.SelectAll();
            foreach (Person p in pList)
                Console.WriteLine(p.FirstName);
            Person personToUpdate = pList[0];
            personToUpdate.FirstName += "yyy";
            personDB.Update(personToUpdate);
            int y = personDB.SaveChanges();
            Console.WriteLine($"{y} rows were updated");


            Console.WriteLine("------StudentDB-----");
            StudentDB studentDB = new();
            StudentList sList = studentDB.SelectAll();
            foreach (Student s in sList)
                Console.WriteLine(s.Tel);
            Student studentToUpdate = sList[0];
            studentToUpdate.Tel += "zzz";
            studentDB.Update(studentToUpdate);
            int z = studentDB.SaveChanges();
            Console.WriteLine($"{z} rows were updated");


            Console.WriteLine("------TeacherDB-----");
            TeacherDB teacherDB = new();
            TeacherList tList = teacherDB.SelectAll();
            foreach (Teacher t in tList)
            {
                Console.WriteLine(t.FirstName);
                Console.WriteLine(t.IsEducator);
                Console.WriteLine(t.StartWorkingDate);
            }
            Teacher teacherToUpdate = tList[0];
            teacherToUpdate.FirstName += "zzz";
            teacherToUpdate.IsEducator = true;
            //teacherToUpdate.StartWorkingDate = "";
            teacherDB.Update(teacherToUpdate);
            int h = teacherDB.SaveChanges();
            Console.WriteLine($"{h} rows were updated");

            Console.WriteLine("------TeacherForStudentDB-----");
            TeacherForStudentDB teacherforstudentDB = new();
            TeacherForStudentList tsList = teacherforstudentDB.SelectAll();
            foreach (TeacherForStudent ts in tsList)
            {
                Console.WriteLine("the Teacher: " + ts.Teach.FirstName + " " + ts.Teach.LastName);
                Console.WriteLine("the Student: " + ts.Stu.FirstName + " " + ts.Stu.LastName);
            }
            TeacherForStudent teacherforstudentToUpdate = tsList[0];
            teacherforstudentToUpdate.Teach.Id += 1;
            teacherforstudentToUpdate.Stu.Id += 1;
            teacherforstudentDB.Update(teacherforstudentToUpdate);
            int g = teacherforstudentDB.SaveChanges();
            Console.WriteLine($"{g} rows were updated");


        }
    }
}
