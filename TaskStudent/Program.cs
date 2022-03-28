using TaskStudent.Models;
using System;
using System.Text.RegularExpressions;
using TaskStudent.exception;

namespace TaskStudent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "";
            string surname = "";
            int age = 0;
            double salaryOfHour = 0;
            double workingHour = 0;
            double iqRank = 0;
            double  languageRank = 0;
            int choice;
            do
            {
               Starting:
                try 
                { 
                Console.WriteLine("[0]-About program ");
                choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException) 
                {
                    Console.WriteLine("Only int numbers allowed");
                    goto Starting;
                }
                switch (choice)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine($"[1]-Calculate employee salary\n[2]-Calculate student exam\n[3]-Stop program");
                        break;
                    case 1:
                        InputEmployee(name, surname, age, ref workingHour, ref salaryOfHour);
                        Employee employeer = new Employee(name, surname, age, workingHour, salaryOfHour);
                        Console.WriteLine($"Result: {employeer.CalculateSalary()} Azn");
                        break;
                    case 2:
                        InputStudent(name, surname, age, ref iqRank, ref languageRank);
                        Student stdudent = new Student(name, surname, age, iqRank, languageRank);
                        Console.WriteLine($"Result: {stdudent.ExamResult()} Point");
                        double result = stdudent.ExamResult();
                        StudentIsPass(result);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Program stopped");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong input [0]-About program");
                        break;
                }
            } while (choice != 3);
        }
        static void InputEmployee(string name, string surname, int age, ref double workingHour, ref double salaryOfHour)
        {
            CheckName(name);
            CheckSurname(surname);
            CheckEmployeeAge(age);
            CheckSalaryWorkingHour(ref workingHour, ref salaryOfHour);
        }
        static void InputStudent(string name, string surname, int age, ref double mathPoint, ref double azLangPoint)
        {
            CheckName(name);
            CheckSurname(surname);
            CheckStudentAge(age);
            CheckMathPointInput(ref mathPoint);
            CheckAzLangPointInput(ref azLangPoint);
        }
        static void CheckName(string name)
        {
           InputCheck:
            try
            {
                Console.Write("Enter name : ");
                name = Console.ReadLine();
                InputCheck(name);
                if (String.IsNullOrEmpty(name))
                    throw new NullEmptyexception("You must enter name"); 
            }
            catch (Exception exception) 
            {
                Console.WriteLine($"Unexpected error:  { exception.Message }");
                goto InputCheck;
            }
        }
        public static bool InputCheck(string name)
        {
            Regex regex = new Regex(@"^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$");
            Match match = regex.Match(name);
            if (match.Success)
                return true;
            else
                throw new NullEmptyexception("Enter Correctly");
        }

        static void CheckSurname(string surname)
        {
        InputCheck:
            try
            {
                Console.Write("Enter Surname : ");
                surname = Console.ReadLine();
                InputCheck(surname);
                if (String.IsNullOrEmpty(surname))
                    throw new NullEmptyexception("You must enter Surname");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Unexpected error:  { exception.Message }");
                goto InputCheck;
            }
        }


        static void CheckEmployeeAge(int age)
        {
        age:
            try
            {
                Console.Write("Enter age: ");
                age = Convert.ToInt32(Console.ReadLine());
                if (age < 18 || age > 70) throw new NotAvaiable("You age is not compitable for work");
            }
            catch (FormatException)
            {
                Console.WriteLine("Only int numbers allowed");
                goto age;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Unexpected error:  { exception.Message }");
                goto age;
            }
        }

        static void CheckSalaryWorkingHour(ref double salaryOfHour, ref double workingHour)
        {
        salary:
            try
            {

                Console.Write("Enter monthly work hour: ");
                workingHour = Convert.ToDouble(Console.ReadLine());
                if (workingHour < 1 || workingHour > 246) throw new  NotAvaiable("Montly work time must 1-246 interval");//31day working in 8 housr 246hour.I dont select
                Console.Write("Enter your hourly salary: ");
                salaryOfHour = Convert.ToDouble(Console.ReadLine());
                if (salaryOfHour <= 0 || (salaryOfHour * workingHour) < 250) throw new NotAvaiable($"Minumum monthly salary is 250Azn\nYou monthly salary is:{ salaryOfHour * workingHour }");
            }
            catch (FormatException)
            {
                Console.WriteLine("Only int numbers allowed");
                goto salary;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Unexpected error:  { exception.Message }");
                goto salary;
            }
        }

        static void CheckStudentAge(int age)
        {
           age:
            try
            {
                Console.Write("Enter age: ");
                age = Convert.ToInt32(Console.ReadLine());
                if (age < 6 || age > 20)
                    throw new NotAvaiable("You age is not compitable");
            }catch (FormatException) 
            {
                Console.WriteLine("Only int numbers allowed");
                goto age;
            }
            catch (Exception exception) 
            {
                Console.WriteLine($"Unexpected error:  { exception.Message }");
                goto age;
            }   
        }

        static void CheckMathPointInput(ref double mathPoint)
        {
        mathPoint:
            try
            {
                Console.Write("Enter math result : ");
                mathPoint = Convert.ToDouble(Console.ReadLine());
                if (mathPoint > 100 || mathPoint < 0)
                    throw new NotAvaiable("Math result must be 0-100 interval");
            }
            catch (FormatException)
            {
                Console.WriteLine("Only int numbers allowed");
                goto mathPoint;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Unexpected error:  { exception.Message }");
                goto mathPoint;
            }
        }

        static void CheckAzLangPointInput(ref double azLangPoint)
        {
        azLangPoint:
            try
            {
                Console.Write("Enetr Az language point: ");
                azLangPoint = Convert.ToDouble(Console.ReadLine());
                if (azLangPoint > 100 || azLangPoint < 0)
                    throw new NotAvaiable("Az language result must be 0-100 interval");
            }
            catch (FormatException)
            {
                Console.WriteLine("Only int numbers allowed");
                goto azLangPoint;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Unexpected error:  { exception.Message }");
                goto azLangPoint;
            }
        }
        static void StudentIsPass(double result)
        {
            if (result >= 120)
                Console.WriteLine("Your passed exam\nCongrualation!..");
            Console.WriteLine("Failed exam!:(");
        }
    }
    
}
