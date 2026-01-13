using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Student : Person
    {
        private string tel;

        public string Tel { get => tel; set => tel = value; }
    }
}
