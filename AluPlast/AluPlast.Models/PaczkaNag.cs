namespace AluPlast.Models
{
    public class PaczkaNag
    {
        //public ObservableCollection<PaczkaElem> ElementyPaczki = new ObservableCollection<PaczkaElem>();
        public Listing WybranyListing { get; set; }
        public int Id { get; set; }
        public int Numer { get; set; }
        public PaczkiTyp Typ { get; set; }
        public PaletyRodzaj RodzajPalety { get; set; }
        public string KontrahentAkronim { get; set; }
        //public Kontrahent Kontrahent { get; set; }
        
        
        //public Terminal Terminal { get; set; }
        //public List<PaczkaElem> ElementyPaczki = new List<PaczkaElem>();
        //public Listing Listing { get; set; }
        //public int Id { get; set; }
        //public int PaletyNumer { get; set; }
        //public int PaczkiTyp { get; set; }
        //public int TerminalId { get; set; }
        //public string Operator { get; set; }
    }
}
