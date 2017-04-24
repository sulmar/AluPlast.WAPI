using System;

namespace AluPlast.Models
{
    public class PaletyRodzaj : IComparable<PaletyRodzaj>
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }

        public override string ToString()
        {
            return Nazwa;
        }

        public int CompareTo(PaletyRodzaj other)
        {
            return Id.CompareTo(other.Id);
        }
    }
}
