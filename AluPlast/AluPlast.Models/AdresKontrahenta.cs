namespace AluPlast.Models
{
    public class AdresKontrahenta : Base
    {
        private int _numer;
        public TypAdresu TypAdresu { get; set; }

        public int Numer
        {
            get { return _numer; }
            set
            {
                _numer = value;
                //OnPropertyChanged();
            }
        }

        public string Akronim { get; set; }

    }
}
