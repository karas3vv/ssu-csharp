using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }

    public class TriangleFinder
    {
        public static (SPoint, SPoint, SPoint, double) FindLargestPerimeterTriangle(List<SPoint> points)
        {
            double maxPerimeter = 0;
            SPoint maxP1 = default, maxP2 = default, maxP3 = default;

            int n = points.Count;
            for (int i = 0; i < n - 2; i++)
            {
                for (int j = i + 1; j < n - 1; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        // Вычисляем периметр треугольника, образованного точками i, j, k
                        double perimeter = SPoint.Distance(points[i], points[j]) + SPoint.Distance(points[j], points[k]) + SPoint.Distance(points[k], points[i]);

                        // Сравниваем с текущим максимальным периметром
                        if (perimeter > maxPerimeter)
                        {
                            maxPerimeter = perimeter;
                            maxP1 = points[i];
                            maxP2 = points[j];
                            maxP3 = points[k];
                        }
                    }
                }
            }
            return (maxP1, maxP2, maxP3, maxPerimeter);
        }
    }

    class Programm
    {
        static void Main(string[] args)
        {
            List<SPoint> points = new List<SPoint>();
            using (StreamReader reader1 = new StreamReader("D:/Projects/C#/pr14_I_n18/file1.txt"))
            {
                string line;
                while ((line = reader1.ReadLine()) != null)
                {
                    var parts = line.Split();
                    if (parts.Length == 3 && double.TryParse(parts[0], out double x) && double.TryParse(parts[1], out double y) && double.TryParse(parts[2], out double z))
                    {
                        points.Add(new SPoint(x, y, z));
                    }
                }
            }

            if (points.Count < 3)
            {
                using (StreamWriter resultFile = new StreamWriter("D:/Projects/C#/pr14_I_n18/result.txt"))
                {
                    resultFile.WriteLine("Недостаточно точек для формирования треугольника.");
                }
                return;
            }

            var (p1, p2, p3, maxPerimeter) = TriangleFinder.FindLargestPerimeterTriangle(points);

            using (StreamWriter resultFile = new StreamWriter("D:/Projects/C#/pr14_I_n18/result.txt"))
            {
                resultFile.WriteLine($"Точки с наибольшим периметром: ({p1.X}, {p1.Y}, {p1.Z}), ({p2.X}, {p2.Y}, {p2.Z}), ({p3.X}, {p3.Y}, {p3.Z})");
                resultFile.WriteLine($"Периметр: {maxPerimeter}");
            }

            Console.WriteLine("Данные успешно записаны в файл result.txt");
        }
    }
}