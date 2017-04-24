namespace AluPlast.Models
{
    public class Zasob
    {
        public Towar Towar { get; set; }
        public Magazyn Magazyn { get; set; }
        public Lokalizacja Lokalizacja { get; set; }
        public Lokalizacja LokalizacjaNowa { get; set; }
        public decimal Ilosc { get; set; }
        public decimal IloscNowa { get; set; }
        public Dostawa Dostawa { get; set; }
        public string LokalizacjaAdresIlosc => Lokalizacja == null ? null : $"{Lokalizacja.Adres} / {Ilosc}";
    }

}
