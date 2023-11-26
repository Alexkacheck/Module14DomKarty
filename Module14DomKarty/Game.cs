using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module14DomKarty
{
    public class Game
    {
        public List<Player> Players { get; private set; }
        public List<Karta> Koloda;

        public Game(int numberOfPlayers)
        {
            Players = new List<Player>();
            InitializePlayers(numberOfPlayers);
            InitializeKoloda();
            ShuffleKoloda();
            RazdatKarty();
        }

        private void InitializePlayers(int numberOfPlayers)
        {
            if (numberOfPlayers < 2)
                throw new ArgumentException("Минимальное количество игроков - 2.");

            Players = new List<Player>();
            for (int i = 1; i <= numberOfPlayers; i++)
            {
                Players.Add(new Player($"Игрок_{i}"));
            }
        }

        private void InitializeKoloda()
        {
            Koloda = new List<Karta>();
            string[] masti = { "Черви", "Бубны", "Крести", "Пики" };
            string[] dostoinstva = { "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };

            foreach (var mast in masti)
            {
                foreach (var dostoinstvo in dostoinstva)
                {
                    Koloda.Add(new Karta(mast, dostoinstvo));
                }
            }
        }

        private void ShuffleKoloda()
        {
            var random = new Random();
            Koloda = Koloda.OrderBy(k => random.Next()).ToList();
        }

        private void RazdatKarty()
        {
            int kartyNaIgroka = Koloda.Count / Players.Count;

            for (int i = 0; i < Players.Count; i++)
            {
                Players[i].Cards.AddRange(Koloda.GetRange(i * kartyNaIgroka, kartyNaIgroka));
            }
        }

        public void Igrat()
        {
            while (Players.All(p => p.Cards.Any()))
            {
                var cardsOnTable = new List<Karta>();

                foreach (var player in Players)
                {
                    if (player.Cards.Any())
                    {
                        var card = player.Cards.First();
                        Console.WriteLine($"{player.Name} кладет карту: {card.Dostoinstvo} {card.Mast}");
                        cardsOnTable.Add(card);
                        player.Cards.RemoveAt(0);
                    }
                }

                var maxCardValue = FindWinningCard(cardsOnTable).Dostoinstvo;

                var winningPlayer = Players.FirstOrDefault(p => p.Cards.Any() && p.Cards.First().Dostoinstvo == maxCardValue);

                if (winningPlayer != null)
                {
                    Players.ForEach(p => winningPlayer.Cards.Add(p.Cards.First()));
                    Players.ForEach(p => p.Cards.RemoveAt(0));
                    Console.WriteLine($"Игрок {winningPlayer.Name} забирает раунд.");
                }
            }

            var winner = Players.First(p => !p.Cards.Any());
            Console.WriteLine($"Победитель: {winner.Name}!");
        }

        private Karta FindWinningCard(List<Karta> cards)
        {
            var cardValues = new Dictionary<string, int>
        {
            {"6", 6}, {"7", 7}, {"8", 8}, {"9", 9}, {"10", 10},
            {"Валет", 11}, {"Дама", 12}, {"Король", 13}, {"Туз", 14}
        };

            return cards.OrderByDescending(c => cardValues[c.Dostoinstvo]).First();
        }
    }
}