using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PersonList : List<Person>
    {
        public PersonList() { }
        public PersonList(IEnumerable<Person> list) : base(list) { }
        public PersonList(IEnumerable<BaseEntity> list) : base(list.Cast<Person>().ToList()) { }
    }
}
