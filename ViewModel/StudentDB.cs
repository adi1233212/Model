using Model;
using ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class StudentDB:PersonDB
    {
        public StudentList SelectAll()
        {
            command.CommandText = $"SELECT Person.id, Person.firstName, Person.lastName, " +
                                  $" Person.cityCode, Student.tel " +
                                  $" FROM (Person INNER JOIN Student ON Person.id = Student.id)";

            StudentList sList = new StudentList(base.Select());
            return sList;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Student s = entity as Student;
            s.Tel = reader["tel"].ToString();

            base.CreateModel(entity);
            return s;
        }

        public override BaseEntity NewEntity()
        {
            return new Student();
        }

        private static StudentList list = new StudentList();

        public static Person SelectById(int id)
        {
            StudentDB db = new StudentDB();
            list = db.SelectAll();

            Student g = list.Find(item => item.Id == id);
            return g;
        }



    }
}
