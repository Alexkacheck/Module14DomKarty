using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module14DomKarty
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите количество игроков (минимум 2): ");
            int numberOfPlayers = int.Parse(Console.ReadLine());

            try
            {
                Game game = new Game(numberOfPlayers);
                // Пример игровой логики
                game.Igrat();

                // Пример вывода карт игроков после окончания игры
                Console.WriteLine("Вскрылись карты игроков:");
                foreach (var player in game.Players)
                {
                    player.ShowCards();
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }

}
    

        
    

