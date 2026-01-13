using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TeacherForStudentList : List<TeacherForStudent>
    {
        public TeacherForStudentList() { }
        public TeacherForStudentList(IEnumerable<TeacherForStudent> list) : base(list) { }
        public TeacherForStudentList(IEnumerable<BaseEntity> list) : base(list.Cast<TeacherForStudent>().ToList()) { }
    }
}
