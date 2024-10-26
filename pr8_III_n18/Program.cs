using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace pr8_III_n18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст: ");
            string text = Console.ReadLine();

            Console.WriteLine("Введите значение n: ");
            int n = int.Parse(Console.ReadLine());

            // Приводим строку к нижнему регистру и удаляем все знаки препинания
            string cleanedText = Regex.Replace(text.ToLower(), @"[^\w\s]", "");

            // Разбиваем строку на слова
            string[] words = cleanedText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Список для хранение уникакльных слов и их количество
            string[] uniqueWords = new string[words.Length];
            int[] wordCounts = new int[words.Length];
            int uniqueCount = 0;

            foreach (string word in words)
            {
                // Проверка на то, встречалось ли слово ранее
                int index = Array.IndexOf(uniqueWords, word, 0, uniqueCount);

                if (index < 0)
                {
                    uniqueWords[uniqueCount] = word;
                    wordCounts[uniqueCount] = 1;
                    uniqueCount++;
                }
                else
                {
                    wordCounts[index]++;
                }
            }

            // Выводим слова, которые встречаются более n раз
            Console.WriteLine($"Слова, которые встречаются более {n} раз:");
            for (int i = 0; i < uniqueCount; i++)
            {
                if (wordCounts[i] > n)
                {
                    Console.WriteLine(uniqueWords[i]);
                }
            }
        }
    }
}


// Привет, мир! Привет всем. Мир полон чудес. Чудеса везде.