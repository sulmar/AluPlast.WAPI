namespace AluPlast.Models
{
    public class Towar
    {
        //public List<Lokalizacja> Lokalizacje { get; set; }
        public int Numer { get; set; }
        public string Kod { get; set; }
        public string Nazwa { get; set; }
        public string Jm { get; set; }
        public decimal Waga { get; set; }
        public decimal WPalecie { get; set; }

        public override string ToString()
        {
            return Kod;
        }
    }
}