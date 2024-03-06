using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            while (count > 0)
            {
                string[] inputToken = Console.ReadLine()
                    .Split()
                    .ToArray();
                string firstName = inputToken[0];
                string lastName = inputToken[1];
                double grade = double.Parse(inputToken[2]);
                Student student = new Student(firstName, lastName, grade);
                students.Add(student);
                count--;
            }

            students = students.OrderByDescending(x => x.Grade).ToList();
            foreach (Student student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }
    public class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
    }
}