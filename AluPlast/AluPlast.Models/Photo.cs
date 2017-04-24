using System.IO;

namespace AluPlast.Models
{
    public class Photo : Base
    {
        private Stream _content;
        public int PhotoId { get; set; }

        public Stream Content
        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }


        public string Description { get; set; }
    }
}
