namespace AluPlast.Models
{
    public class ListingElem : Base
    {
        private decimal _iloscSpakowana;
        private decimal _iloscDoRealizacji;
        public int Lp { get; set; }
        public Towar Towar { get; set; }
        public decimal IloscZamawiana { get; set; }
        public decimal Przelicznik { get; set; }

        public decimal IloscSpakowana
        {
            get { return _iloscSpakowana; }
            set
            {
                _iloscSpakowana = value;
                OnPropertyChanged();
            }
        }

        public string IloscWyswietlana => $"{IloscZamawiana} / {IloscZamawiana - IloscSpakowana} {Towar.Jm}";
        public decimal IloscDoRealizacji
        {
            get
            {
                _iloscDoRealizacji = IloscZamawiana - IloscSpakowana;
                return _iloscDoRealizacji;
            }
            set
            {
                _iloscDoRealizacji = value;
                OnPropertyChanged();
            }
        }

        public decimal IloscWInnych { get; set; }
        public decimal IloscPobrana { get; set; }
        public Lokalizacja LokalizacjaPobrana { get; set; }
        public bool Selected { get; set; }
        public override string ToString()
        {
            return Towar.Kod;
        }
    }
}
