using System.Collections.ObjectModel;

namespace AluPlast.Models
{
    public class Kontrahent : GenericBase<string>
    {
        public ObservableCollection<Listing> Listingi = new ObservableCollection<Listing>();

        public int AdresGidNumer { get; set; }

        public string Akronim { get; set; }

        public string Nazwa1 { get; set; }

        public string Miasto { get; set; }

        public string Ulica { get; set; }
        public string Adres => $"{Ulica}, {Miasto}";
        public override string ToString()
        {
            return Akronim;
        }

        public override string Id
        {
            get
            {
                return Akronim;
            }

            set
            {
                Akronim = value;
            }
        }
    }
}
