using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr16_II_n19
{
    struct Student
    {
        public string Surname;      // Фамилия
        public string Faculty;      // Факультет
        public int Course;          // Курс
        public string Group;        // Группа
        public int Exam1;           // Результат 1-го экзамена
        public int Exam2;           // Результат 2-го экзамена
        public int Exam3;           // Результат 3-го экзамена

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
            string inputFile = "D:/Projects/ssu-csharp/pr16_II_n19/input.txt";
            string outputFile = "D:/Projects/ssu-csharp/pr16_II_n19/output.txt";

            // Чтение данных из файла и создание списка студентов
            List<Student> students = File.ReadAllLines(inputFile)
                                          .Select(line =>
                                          {
                                              var parts = line.Split(',');
                                              return new Student(
                                                  parts[0].Trim(),               // Фамилия
                                                  parts[1].Trim(),               // Факультет
                                                  int.Parse(parts[2]),    // Курс
                                                  parts[3].Trim(),               // Группа
                                                  int.Parse(parts[4]),    // Экзамен 1
                                                  int.Parse(parts[5]),    // Экзамен 2
                                                  int.Parse(parts[6])     // Экзамен 3
                                              );
                                          })
                                          .ToList();

            // Фильтрация студентов с оценками "отлично" (все экзамены >= 90) и сортировка по курсу
            var excellentStudents = students
                .Where(s => s.Exam1 >= 90 && s.Exam2 >= 90 && s.Exam3 >= 90)
                .OrderBy(s => s.Course)
                .ToList();

            // Проверка наличия данных для записи
            if (excellentStudents.Count == 0)
            {
                Console.WriteLine("Нет студентов, обучающихся на \"отлично\".");
                return;
            }

            // Запись результатов в output.txt
            File.WriteAllLines(outputFile, excellentStudents.Select(s =>
                $"{s.Surname}, {s.Faculty}, {s.Course}, {s.Group}, {s.Exam1}, {s.Exam2}, {s.Exam3}"));

            Console.WriteLine($"Файл успешно создан: {outputFile}");
        }
    }
}