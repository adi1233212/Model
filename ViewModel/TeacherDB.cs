using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
            Teacher t = entity as Teacher;
            if (t != null)
            {
                string sqlStr = $"UPDATE Teacher SET IsEducator=@isE , StartWorkingDate =@sDate WHERE ID=@id";

                command.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@isE", t.IsEducator));
                cmd.Parameters.Add(new OleDbParameter("@id", t.StartWorkingDate));
            }
        }
    }
}

