using Model;
using ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace ViewModel
{
    public class TeacherForStudentDB:BaseDB
    {
        public TeacherForStudentList SelectAll()
        {
            command.CommandText = $"SELECT Id, IdTeacher, IdStudent" + " FROM TeacherForStudent";
            TeacherForStudentList tsList = new TeacherForStudentList(base.Select());
            return tsList;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            TeacherForStudent ts = entity as TeacherForStudent;
            ts.Teach = TeacherDB.SelectById(int.Parse(reader["IdTeacher"].ToString()));
            ts.Stu = StudentDB.SelectById(int.Parse(reader["IdStudent"].ToString()));

            base.CreateModel(entity);
            return ts;
        }

        public override BaseEntity NewEntity()
        {
            return new TeacherForStudent();
        }

        private static TeacherForStudentList list = new TeacherForStudentList();

        public static TeacherForStudent SelectById(int id)
        {
            TeacherForStudentDB tsb = new TeacherForStudentDB();
            list = tsb.SelectAll();

            TeacherForStudent g = list.Find(item => item.Id == id);
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
            TeacherForStudent tfs = entity as TeacherForStudent;
            if (tfs != null)
            {
                string sqlStr = $"UPDATE TeacherForStudent SET IdTeacher =@idT , IdStudent =@idS WHERE ID=@id";

                command.CommandText = sqlStr;
                cmd.Parameters.Add(new OleDbParameter("@idT", tfs.Teach.Id));
                cmd.Parameters.Add(new OleDbParameter("@idS", tfs.Stu.Id));
            }
        }
    }
}

