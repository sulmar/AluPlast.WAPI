using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluPlast.Models
{
    public class Odczyt
    {
        public Towar Towar { get; set; }
        public decimal Ilosc { get; set; }
        public Lokalizacja Lokalizacja { get; set; }
        public int Przejscie { get; set; }
        public int Arkusz { get; set; }
        public Magazyn Magazyn { get; set; }
    }
}
