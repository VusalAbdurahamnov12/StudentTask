using System;
using System.Collections.Generic;
using System.Text;

namespace TaskStudent.Models
{
    abstract class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual int Age { get; set; }
    }
}
