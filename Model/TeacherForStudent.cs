using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TeacherForStudent : BaseEntity
    {
        private Student stu;
        private Teacher teach;

        public Teacher Teach { get => teach; set => teach = value; }
        internal Student Stu { get => stu; set => stu = value; }
    }
}
