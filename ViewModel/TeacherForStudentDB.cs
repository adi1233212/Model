using Model;
using ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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



    }
}

