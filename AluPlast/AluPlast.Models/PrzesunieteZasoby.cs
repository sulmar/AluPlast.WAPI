using System;

namespace AluPlast.Models
{
    public class PrzesunietyZasob : Zasob
    {
        public string NumerDokumentu { get; set; }
        public string LokalizacjaStara => Lokalizacja.Adres;
        public DateTime CreateDate { get; set; }

        public string CreateDateView => CreateDate.ToString("yyyy-MM-dd : hh:mm");


    }
}
