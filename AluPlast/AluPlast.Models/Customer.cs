﻿namespace AluPlast.Models
{
    public class Customer : Base
    {
        public AdresKontrahenta Adres { get; set; }
        public string Akronim { get; set; }
        public int GidNumer { get; set; }
        public string Kraj { get; set; }
        public string Miasto { get; set; }
        public string Nazwa { get; set; }
        public string Nazwa2 { get; set; }
        public string Nazwa3 { get; set; }
        public string Nip { get; set; }

        public override int Id
        {
            get
            {
                return GidNumer;
            }

            set
            {
                GidNumer = value;
            }
        }
    }
}
