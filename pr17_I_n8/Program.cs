using pr17_I_n8;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr17_I_n8
{
    class ImmutableString
    {
        // 1. Закрытое поле
        private string line;

        // 2. Конструкторы, позволяющие создать строку с заданной размерностью;
        public ImmutableString(int length)
        {
            line = new string(' ', length);
        }

        // на основе заданного строкового литерала;
        public ImmutableString(string line)
        {
            this.line = string.Copy(line);
        }

        // на основе существующего экземпляра класса (конструктор копирования).
        public ImmutableString(ImmutableString other)
        {
            line = string.Copy(other.line);
        }


        // 3. Методы, позволяющие подсчитать количество цифр в строке;
        public int CountDigits()
        {
            int count = 0;
            foreach (char c in this.line)
            {
                if (Char.IsDigit(c))
                    count++;
            }
            return count;
        }

        // подсчитать сумму цифр в строке.
        public int SumOfDigits()
        {
            int sum = 0;
            foreach (char c in this.line)
            {
                if (Char.IsDigit(c))
                {
                    sum += c - '0';  // преобразуем символ в число
                }
            }
            return sum;
        }

        // 4. Перегрузка методов Object. ToString возвращает строковое представление
        public override string ToString()
        {
            return string.Copy(line);
        }

        // GetHashCode возвращает хеш-код 
        public override int GetHashCode()
        {
            return line.GetHashCode();
        }

        // Equals проверяет равен ли текущий объект другому
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ImmutableString))
                return false;

            ImmutableString other = (ImmutableString)obj;
            return string.Equals(this.line, other.line, StringComparison.OrdinalIgnoreCase);
        }

        // 5. Свойство: для получения доступа к закрытому полю класса (доступное для чтения и записи);
        // Если отсутствует set - доступно только для чтения. Если отсутствует get - доступно только для записи.
        public string Line
        {
            get { return string.Copy(line); }
            set { line = string.Copy(value); }
        }

        // возвращающее общее количество символов в строке (доступное только для чтения);
        public int TotalLength
        {
            get
            {
                string copyLine = string.Copy(line);
                return copyLine.Length;
            }
        }

        // 6. Индексатор, позволяющий по индексу обращаться к соответствующему символу строки
        // (доступный только для чтения).
        public char this[int i]
        {
            get
            {
                if (i < TotalLength)
                {
                    return line[i];
                }
                else
                {
                    throw new Exception("Неправильный индекс");
                }
            }
        }

        // 7. Перегрузку: Операции унарного !: возвращает значение true, если строка не пустая, иначе false;
        public static bool operator !(ImmutableString myString)
        {
            return myString.TotalLength != 0;
        }

        // констант true и false: обращение к экземпляру класса дает значение true если строка
        // является палиндромом, false – противном случае;

        public static bool IsPalindrome(ImmutableString myString)
        {
            int start = 0;
            int end = myString.TotalLength - 1;

            while (start < end)
            {
                if (char.ToLower(myString[start]) != char.ToLower(myString[end]))
                {
                    return false;
                }
                start++;
                end--;
            }
            return true;
        }

        public static bool operator true(ImmutableString myString)
        {
            return IsPalindrome(myString);
        }

        public static bool operator false(ImmutableString myString)
        {
            return !IsPalindrome(myString);
        }

        // операции &: возвращает значение true, если строковые поля двух объектов
        // посимвольно равны (без учета регистра), иначе false;
        public static bool operator &(ImmutableString obj1, ImmutableString obj2)
        {
            if (obj1.TotalLength != obj2.TotalLength)
                return false;

            for (int i = 0; i < obj1.TotalLength; i++)
            {
                if (char.ToLower(obj1[i]) != char.ToLower(obj2[i]))
                    return false;
            }

            return true;
        }

        // операции преобразования класса-строка в тип string (и наоборот) строку в класс
        public static implicit operator ImmutableString(string s)
        {
            return new ImmutableString(s);
        }

        // класс в строку
        public static implicit operator string(ImmutableString s)
        {
            return string.Copy(s.Line);
        }
    }
}

namespace MyProgram
{
    class Program
    {
        static void Main()
        {
            using (StreamReader input = new StreamReader("D:/Projects/ssu-csharp/pr17_I_n8/input.txt"))
            {
                using (StreamWriter output = new StreamWriter("D:/Projects/ssu-csharp/pr17_I_n8/output.txt"))
                {
                    string inputLine = input.ReadLine();
                    ImmutableString immutableString = new ImmutableString(inputLine);

                    output.WriteLine($"Исходная строка: {immutableString.ToString()}");
                    int digitCount = immutableString.CountDigits();
                    output.WriteLine($"3. Количество цифр: {digitCount}");
                    int digitSum = immutableString.SumOfDigits();
                    output.WriteLine($"3. Сумма цифр: {digitSum}");
                    output.WriteLine($"6. Символ на заданной позиции: {immutableString[9]}");
                    output.WriteLine($"5. Длина строки: {immutableString.TotalLength}");

                    output.WriteLine($"4. Хеш-код строки: {immutableString.GetHashCode()}");

                    string strFor4p1 = "test";
                    output.WriteLine($"4. Равны ли два объекта (сравнение со строкой - {strFor4p1}): {immutableString.Equals(new ImmutableString(strFor4p1))}");

                    string strFor4p2 = "hello world 1703 1 1 3071 dlrow olleh";
                    output.WriteLine($"4. Равны ли два объекта (сравнение bсо строкой - {strFor4p2}): {immutableString.Equals(new ImmutableString(strFor4p2))}");
                    output.WriteLine($"4. Тип строки: {immutableString.GetType()}");

                    output.WriteLine($"7. Проверка на пустоту: {!immutableString}");
                    if (!immutableString)
                    {
                        output.WriteLine("Строка не пустая");
                    }
                    else
                    {
                        output.WriteLine("Строка пустая");
                    }

                    output.WriteLine($"7. Является ли строка палиндромом: {ImmutableString.IsPalindrome(immutableString)}");

                    ImmutableString myString2 = new ImmutableString("HELLO WORLD 1702 1 1 2071 DLROW OLLEH");
                    output.WriteLine($"7. Равны ли две строки посимвольно (сравнение со строкой {myString2}): {immutableString & myString2}");


                    string testString = "test";
                    ImmutableString myString3 = testString;
                    testString = myString3;
                    output.WriteLine($"7. Преобразование класса в строку: {myString3}, {myString3.GetType()}");
                    output.WriteLine($"7. Преобразование строки в класс: {testString}, {testString.GetType()}");
                }
            }
        }
    }
}