using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

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

        public static Student SelectById(int id)
        {
            StudentDB db = new StudentDB();
            list = db.SelectAll();

            Student g = list.Find(item => item.Id == id);
            return g;
        }
        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Student s = entity as Student;
            if (s != null)
            {
                string sqlStr = $"UPDATE Student SET Tel=@tel WHERE ID=@id";

                command.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@tel", s.Tel));
                cmd.Parameters.Add(new OleDbParameter("@id", s.Id));
            }
        }
    }
}

