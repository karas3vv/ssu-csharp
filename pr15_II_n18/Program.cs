using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr15_II_n18
{
    struct Student
    {
        public string Surname;      // Фамилия
        public string Faculty;      // Факультет
        public int Course;          // Курс
        public string Group;        // Группа
        public int Exam1;           // Экзамен 1
        public int Exam2;           // Экзамен 2
        public int Exam3;           // Экзамен 3

        // Конструктор
        public Student(string surname, string faculty, int course, string group, int exam1, int exam2, int exam3)
        {
            Surname = surname;
            Faculty = faculty;
            Course = course;
            Group = group;
            Exam1 = exam1;
            Exam2 = exam2;
            Exam3 = exam3;
        }

        // Метод для красивого вывода информации о студенте
        public override string ToString()
        {
            return $"{Surname} {Course} {Group} {Exam1} {Exam2} {Exam3}";
        }
    }

    internal class Program
    {
        static void Main()
        {
            string inputFile = "D:/Projects/ssu-csharp/pr15_II_n18/input.txt";
            string outputFile = "D:/Projects/ssu-csharp/pr15_II_n18/output.txt";

            // Чтение данных из файла и создание списка студентов
            List<Student> students = File.ReadAllLines(inputFile)
                                          .Select(line =>
                                          {
                                              var parts = line.Split(';');
                                              return new Student(
                                                  parts[0].Trim(),        // Фамилия
                                                  parts[1].Trim(),        // Факультет
                                                  int.Parse(parts[2]),    // Курс
                                                  parts[3].Trim(),        // Группа
                                                  int.Parse(parts[4]),    // Экзамен 1
                                                  int.Parse(parts[5]),    // Экзамен 2
                                                  int.Parse(parts[6])     // Экзамен 3
                                              );
                                          })
                                          .ToList();

            var filteredStudents = from s in students
                                   where s.Exam1 < 3 || s.Exam2 < 3 || s.Exam3 < 3
                                   group s by s.Faculty into g
                                   orderby g.Key
                                   select g;

            // Запись результата в файл
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                foreach (var group in filteredStudents)
                {
                    writer.WriteLine($"Факультет: {group.Key}");
                    foreach (var student in group)
                    {
                        writer.WriteLine(student.ToString());
                    }
                    writer.WriteLine();
                }
            }
            Console.WriteLine("Информация записана в файл output.txt.");
        }
    }
}