using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace pr20_I_n3
{
    class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    class LinkedList<T>
    {
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }

        public LinkedList()
        {
            Head = Tail = null;
        }

        // Добавление элемента в хвост списка
        public void AddToTail(T data)
        {
            var newNode = new Node<T>(data);
            if (Head == null)
            {
                Head = Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                Tail = newNode;
            }
        }

        // Извлечение элемента из головы списка
        public T RemoveFromHead()
        {
            if (Head == null)
            {
                throw new Exception("Список пуст.");
            }

            T data = Head.Data;
            Head = Head.Next;

            if (Head == null)
            {
                Tail = null;
            }

            return data;
        }

        // Просмотр всех элементов
        public string Traverse()
        {
            if (Head == null)
            {
                return "";
            }

            var result = "";
            Node<T> Temp = Head; // Локальная переменная Temp
            while (Temp != null)
            {
                result += Temp.Data + " ";
                Temp = Temp.Next;
            }

            return result.Trim();
        }

        // Вставка элемента y после каждого элемента x
        public void Insert(T x, T y)
        {
            Node<T> Temp = Head; // Локальная переменная Temp
            while (Temp != null)
            {
                if (EqualityComparer<T>.Default.Equals(Temp.Data, x))
                {
                    var newNode = new Node<T>(y);
                    newNode.Next = Temp.Next;
                    Temp.Next = newNode;

                    // Обновление Tail, если вставленный элемент последний
                    if (newNode.Next == null)
                    {
                        Tail = newNode;
                    }

                    // Переход к следующему элементу (пропускаем вставленный)
                    Temp = newNode.Next;
                }
                else
                {
                    Temp = Temp.Next;
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>();
            using (StreamReader reader = new StreamReader("D:/Projects/ssu-csharp/pr20_I_n3/input.txt"))
            {
                string content = reader.ReadToEnd();
                var matches = Regex.Matches(content, @"-?\d+");
                foreach (Match match in matches)
                {
                    if (int.TryParse(match.Value, out int number))
                    {
                        numbers.Add(number);
                    }
                }
            }

            var list = new LinkedList<int>();
            foreach (var num in numbers)
            {
                list.AddToTail(num);
            }

            string originalSequence = list.Traverse();

            Console.Write("Введите значение x: ");
            int x = int.Parse(Console.ReadLine());

            Console.Write("Введите значение y: ");
            int y = int.Parse(Console.ReadLine());
            list.Insert(x, y);

            string finalSequence = list.Traverse();

            using (StreamWriter writer = new StreamWriter("D:/Projects/ssu-csharp/pr20_I_n3/output.txt"))
            {
                writer.WriteLine(originalSequence);
                writer.WriteLine(finalSequence);
            }
            Console.WriteLine("Данные записаны в output.txt");
        }
    }
}