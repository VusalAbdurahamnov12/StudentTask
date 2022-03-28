using System;
using System.Collections.Generic;
using System.Text;

namespace TaskStudent.Models
{
    internal class Employee:Person
    {
        private double _SalaryOfHour;
        private double _WorkingHour;
        private int _age;
        public override int Age {
            get
            {
                return _age;
            }
            set
            {
                if (value > 18 || value>70)
                _age = value;
            }
        }
        public double WorkingHour
        {
            get { return _WorkingHour; }
            set
            {

                if (value / 31 <= 8)
                    _WorkingHour = value;
            }
        }
        public double SalaryOfHour
        {
            get { return _SalaryOfHour; }
            set
            {
                if ((value * _WorkingHour) >= 250)
                    _SalaryOfHour = value;
            }
        }
        public Employee(string name,string surname,int age,double salaryOfHour,double workingHour)
        {
            Name = name;
            Surname = surname;
            Age = age;
            WorkingHour = workingHour;
            SalaryOfHour = salaryOfHour;
        }
        public double CalculateSalary()
        {
            return Math.Round(SalaryOfHour * WorkingHour, 2);
        }
    }
}
