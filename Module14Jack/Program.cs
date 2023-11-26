using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Module14Jack
{
    class Program
    {
        static void Main(string[] args)
        {
            // Заданный текст
            string inputText = "Вот дом, Который построил Джек. А это пшеница, Которая в темном чулане хранится В доме, " +
                              "Который построил Джек. А это веселая птица синица, Которая часто ворует пшеницу, " +
                              "Которая в темном чулане хранится В доме, Который построил Джек.";

            // Создаем словарь для хранения статистики
            Dictionary<string, int> wordStatistics = CountWordOccurrences(inputText);

            // Выводим статистику
            Console.WriteLine("Вот инфа:");
            DisplayStatistics(wordStatistics);
        }

        // Метод для подсчета повторений слов в тексте
        static Dictionary<string, int> CountWordOccurrences(string text)
        {
            // Используем регулярное выражение для разделения текста на слова
            string[] words = Regex.Split(text.ToLower(), @"\W+");

            // Создаем словарь для хранения статистики
            Dictionary<string, int> wordStatistics = new Dictionary<string, int>();

            // Подсчитываем повторения слов
            foreach (string word in words)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    if (wordStatistics.ContainsKey(word))
                    {
                        wordStatistics[word]++;
                    }
                    else
                    {
                        wordStatistics[word] = 1;
                    }
                }
            }

            return wordStatistics;
        }

        // Метод для вывода статистики
        static void DisplayStatistics(Dictionary<string, int> wordStatistics)
        {

            Console.WriteLine("+--------------+-------------+");
            Console.WriteLine("|    Слово     | Повторений  |");
            Console.WriteLine("+--------------+-------------+");

            foreach (var entry in wordStatistics)
            {
                Console.WriteLine($"| {entry.Key,-12} | {entry.Value,-11} |");
            }

            Console.WriteLine("+--------------+-------------+");
        }

    }
}
