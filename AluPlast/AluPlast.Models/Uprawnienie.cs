using System.Collections.Generic;
using AluPlast.Models.Enums;

namespace AluPlast.Models
{
    public class Uprawnienie
    {
        public int Upr_Id { get; set; }
        //public string Nazwa { get; set; }
        public UprawnienieTyp Typ { get; set; } //to samo co UpS_Id
        public Program Program { get; set; }
        public bool MaUprawnieniaDoMagazynow { get; set; }
        public bool MaUprawnieniaDoDzialow { get; set; }
        public List<UprawenienieDoMagazynu> UprawenieniaDoMagazynu { get; set; } = new List<UprawenienieDoMagazynu>();
        public List<UprawnienieDoDzialu> UprawnieniaDoDzialow { get; set; } = new List<UprawnienieDoDzialu>();
    }
}
