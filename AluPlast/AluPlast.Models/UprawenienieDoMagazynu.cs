namespace AluPlast.Models
{
    public class UprawenienieDoMagazynu
    {
        public int UpMId { get; set; }
        public int UpM_UprId { get; set; }
        public Magazyn Magazyn { get; set; }
        public bool Zrodlowy { get; set; }
        public bool Docelowy { get; set; }



    }
}
