using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace KT3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            School school = new School();


            Student student1 = new Student("Иван", "Рязанов", 5.51f, "11 А");
            Student student2 = new Student("Илья", "Мазин", 4.14f, "11 B");
            Student student3 = new Student("Олег", "Кислый", 4.54f, "11 Д");
            Student student4 = new Student("Петр", "Святой", 2.35f, "11 Д");
            Student student5 = new Student("Андрей", "Чук", 3.32f, "11 А");
            Student student6 = new Student("Иван", "Санинов", 2.75f, "11 В");
            Student student7 = new Student("Василий", "Сервый", 4.97f, "11 В");
            Student student8 = new Student("Артем", "Исмалов", 3.56f, "11 В");
            Student student9 = new Student("Кирил", "Черный", 3.67f, "11 Д");
            Student student10 = new Student("Андрей", "Керовух", 4.43f, "11 А");

            school.EnrollStudent(student1);
            school.EnrollStudent(student2);
            school.EnrollStudent(student3);
            school.EnrollStudent(student4);
            school.EnrollStudent(student5);
            school.EnrollStudent(student6);
            school.EnrollStudent(student7);
            school.EnrollStudent(student8);
            school.EnrollStudent(student9);
            school.EnrollStudent(student10);

            school.PrintClassInfo("11 А");
        }

        internal class Student
        {
            private string _name;
            private string _lastName;
            private float _midGrade;
            public string ClassName;

            public Student(string name, string lastName, float midGrade, string className)
            {
                _name = name;
                _lastName = lastName;
                _midGrade = midGrade;
                ClassName = className;
            }

            public void PrintInfo()
            {
                Console.WriteLine($"{_name}{ClassName}, " +
                    $"из класса {ClassName}, " +
                    $"имеет среднюю оценку: {_midGrade}");
            }

        }

        public class School
        {

            Dictionary<string, List<Student>> schoolStructure = new();
            public void EnrollStudent(Student student)
            {
                if (schoolStructure.ContainsKey(student.ClassName))
                {
                    schoolStructure[student.ClassName].Add(student);
                }
                else
                {
                    schoolStructure.Add(student.ClassName, new List<Student>());
                    schoolStructure[student.ClassName].Add(student);

                }
            }

            public void PrintClassInfo(string className)
            {
                foreach (Student student in schoolStructure[className])
                {
                    student.PrintInfo();
                }
            }
        }
    }
}
