using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace ViewModel
{
    public class TeacherDB:PersonDB
    {
        public TeacherList SelectAll()
        {
            command.CommandText = $"SELECT Teacher.IsEducator, Teacher.StartWorkingDate, Person.Id, Person.FirstName, Person.LastName," +
                $"Person.CityCode " +
                $"FROM(Person INNER JOIN Teacher ON Person.Id = Teacher.Id)";
                
            TeacherList tList = new TeacherList(base.Select());
            return tList;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Teacher t = entity as Teacher;
            t.IsEducator = bool.Parse(reader["IsEducator"].ToString());
            t.StartWorkingDate = DateTime.Parse(reader["StartWorkingDate"].ToString());

            base.CreateModel(entity);
            return t;
        }

        public override BaseEntity NewEntity()
        {
            return new Teacher();
        }

        private static TeacherList list = new TeacherList();

        public static Teacher SelectById(int id)
        {
            TeacherDB tb = new TeacherDB();
            list = tb.SelectAll();

            Teacher g = list.Find(item => item.Id == id);
            return g;
        }



    }
}
