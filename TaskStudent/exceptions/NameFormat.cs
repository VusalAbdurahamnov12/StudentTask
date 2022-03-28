using System;
using System.Collections.Generic;
using System.Text;

namespace TaskStudent.exceptions
{
    internal class NameFormat:Exception
    {
        public class NameFormatexception : Exception
        {
            public NameFormatexception(string msg) : base(msg) { }
        }
    }
}
