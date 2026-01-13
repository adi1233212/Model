using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Teacher : Person
    {
        private bool isEducator;
        private DateTime startWorkingDate;

        public bool IsEducator { get => isEducator; set => isEducator = value; }
        public DateTime StartWorkingDate { get => startWorkingDate; set => startWorkingDate = value; }
    }
}