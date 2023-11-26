using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module14DomKarty
{
    public class Player
    {
       public string Name { get; }
    public List<Karta> Cards { get; }

    public Player(string name)
    {
        Name = name;
        Cards = new List<Karta>();
    }

    public void ShowCards()
    {
        Console.WriteLine($"{Name}'карты:");
        foreach (var card in Cards)
        {
            Console.WriteLine($"{card.Dostoinstvo} {card.Mast}");
        }
    }
    }
}
