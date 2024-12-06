using System;
using System.Collections.Generic;
using System.IO;

namespace pr14_I_n18
{
    public struct SPoint
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public SPoint(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        // Метод для вычисления расстояния между двумя точками
        public static double Distance(SPoint p1, SPoint p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2) + Math.Pow(p1.Z - p2.Z, 2));
        }

        // Переопределение Equals и GetHashCode для корректного сравнения точек
        public override bool Equals(object obj)
        {
            if (obj is SPoint other)
            {
                return X == other.X && Y == other.Y && Z == other.Z;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (X, Y, Z).GetHashCode();
        }
    }

    public class TriangleFinder
    {
        public static Dictionary<double, List<(SPoint, SPoint, SPoint)>> FindTrianglesWithMaxPerimeter(List<SPoint> points)
        {
            double maxPerimeter = 0;
            var result = new Dictionary<double, List<(SPoint, SPoint, SPoint)>>();

            int n = points.Count;
            for (int i = 0; i < n - 2; i++)
            {
                for (int j = i + 1; j < n - 1; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        // Вычисляем периметр треугольника
                        double perimeter = SPoint.Distance(points[i], points[j]) +
                                           SPoint.Distance(points[j], points[k]) +
                                           SPoint.Distance(points[k], points[i]);

                        // Если найден новый максимальный периметр
                        if (perimeter > maxPerimeter)
                        {
                            maxPerimeter = perimeter;
                            result.Clear();  // Очистить старые результаты, так как найден новый максимальный периметр
                        }

                        // Добавляем треугольник только если его точки уникальны
                        var trianglePoints = new HashSet<SPoint> { points[i], points[j], points[k] };
                        if (trianglePoints.Count == 3) // Убедитесь, что все три точки уникальны
                        {
                            if (!result.ContainsKey(perimeter))
                                result[perimeter] = new List<(SPoint, SPoint, SPoint)>();

                            result[perimeter].Add((points[i], points[j], points[k]));
                        }
                    }
                }
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<SPoint> points = new List<SPoint>();
            string inputFile = "D:/Projects/C#/pr14_I_n18/file1.txt";
            string outputFile = "D:/Projects/C#/pr14_I_n18/result.txt";

            // Чтение данных из файла
            using (StreamReader reader = new StreamReader(inputFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split();
                    if (parts.Length == 3 &&
                        double.TryParse(parts[0], out double x) &&
                        double.TryParse(parts[1], out double y) &&
                        double.TryParse(parts[2], out double z))
                    {
                        points.Add(new SPoint(x, y, z));
                    }
                }
            }

            // Поиск треугольников с максимальным периметром
            var triangles = TriangleFinder.FindTrianglesWithMaxPerimeter(points);

            // Запись результата в файл
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                if (triangles.Count > 0)
                {
                    double maxPerimeter = 0;
                    foreach (var key in triangles.Keys)
                        maxPerimeter = key;

                    writer.WriteLine($"Наибольший периметр: {maxPerimeter:F6}");
                    writer.WriteLine("Треугольники с наибольшим периметром:");
                    foreach (var triangle in triangles[maxPerimeter])
                    {
                        writer.WriteLine($"Точки: ({triangle.Item1.X}, {triangle.Item1.Y}, {triangle.Item1.Z}), " +
                                         $"({triangle.Item2.X}, {triangle.Item2.Y}, {triangle.Item2.Z}), " +
                                         $"({triangle.Item3.X}, {triangle.Item3.Y}, {triangle.Item3.Z})");
                    }
                }
            }

            Console.WriteLine("Данные успешно записаны в файл result.txt");
        }
    }
}
