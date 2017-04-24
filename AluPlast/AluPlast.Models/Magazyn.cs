namespace AluPlast.Models
{
    public class Magazyn
    {
        public int Numer { get; set; }
        public string Kod { get; set; }
        public string Nazwa { get; set; }

        public override string ToString()
        {
            return Kod;
        }
    }
}