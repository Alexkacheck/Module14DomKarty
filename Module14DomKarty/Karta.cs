using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module14DomKarty
{
    public class Karta
    {
        public string Mast { get; set; }
        public string Dostoinstvo { get; set; }

        public Karta(string mast, string dostoinstvo)
        {
            Mast = mast;
            Dostoinstvo = dostoinstvo;
        }
    }
}
