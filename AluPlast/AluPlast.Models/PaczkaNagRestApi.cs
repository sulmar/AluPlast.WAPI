namespace AluPlast.Models
{
    public class PaczkaNagRestApi 
    {
        public int PaczkiNumer { get; set; }
        public int PaczkiTyp { get; set; }
        public string UserAkronim { get; set; }
        public int TerminalId { get; set; }
        public int PaletyRodzajId { get; set; }

        public int Id { get; set; }
        public int TwrNumer { get; set; }
        public int ListingId { get; set; }
        public decimal IloscPobrana { get; set; }
        public string LokalizacjaAdres { get; set; }
        
    }
}
