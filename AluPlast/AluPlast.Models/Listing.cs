using System.Collections.ObjectModel;
using System.Linq;

namespace AluPlast.Models
{
    public class Listing
    {
        //List<PaczkaNag> listaTowarow = new List<PaczkaNag>();
        public ObservableCollection<ListingElem> ElementyListingu = new ObservableCollection<ListingElem>();
        public int Id { get; set; }
        public int Numer { get; set; }
        public int Stan { get; set; }   
        public string Uwagi { get; set; }
        public Uzytkownik Uzytkownik { get; set; }
        public ListingElem ListingElemFirstOrDefault => ElementyListingu.FirstOrDefault(x => x.Selected);
        public int SelectedLvIndex { get; set; }
    }
}
