using System;

namespace AluPlast.Models
{
    public class Terminal
    {
        public int Id { get; set; }
        public string DeviceId { get; set; }
        //public Operator Operator { get; set; }
        public DateTime DataPracy { get; set; }
        public string Name { get; set; }
        //public override string ToString()
        //{
        //    return Id.ToString();
        //}
    }
}
