using System;
using System.Collections.Generic;
using System.Text;

namespace TaskStudent.Models
{
    internal class Student:Person
    {
        private double _IQRank;
        private double _LanguageRank;
        public double IQRank 
        {
            get
            {
                return _IQRank;
            }
            set
            {
                if( value >=0 ||value <= 100)
                {
                    _IQRank = value;
                }
                
            }
        }
        public double LanguageRank 
        { 
            get
            {
                return _LanguageRank;
            }
            set 
            {
                if( value>=0||value <= 100)
                {
                     _LanguageRank=value;
                }
            }
        }
        public Student(string name, string surname, int age, double iqRank, double languageRank)
        {
            Name = name;
            Surname = surname;
            Age = age;
            IQRank = iqRank;
            LanguageRank = languageRank;
        }

        public double ExamResult()
        {
            return IQRank + LanguageRank;
        }
    }
}
