using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AluPlast.ControlLoader.Interfaces;
using AluPlast.Models;

namespace AluPlast.ControlLoader.MockService
{
    public class DbPhotosService : IPhotosService
    {
        ObservableCollection<Photo> _photos = new ObservableCollection<Photo>();
        public ObservableCollection<Photo> Get(int loadId)
        {
            return null;
        }

        public Task<ObservableCollection<Photo>> GetAsync(int loadId)
        {
            var photo = new Photo();
            photo.PhotoId = 77;
            photo.Description = "Moje zdjęcie";
            //photo.Content = reader.GetStream(2);

            var photo2 = new Photo();
            photo2.PhotoId = 88;
            photo2.Description = "Moje zdjęcie 88";
            _photos.Add(photo2);

            return Task.Run(() => _photos);


        }

        public Task<ObservableCollection<Stream>> GetStreamsAsync(int loadId)
        {
            var streams = new ObservableCollection<Stream>();

            var stream = new FileStream("ss", FileMode.Open);
            streams.Add(stream);

            return Task.Run(() => streams);

        }

        public Task<Stream> GetSingleAsync(int loadId, int photoId)
        {

            Stream stream = null;

            stream = new FileStream("ss", FileMode.Open);
            return Task.Run(() => stream);

        }

        public void Add(int loadId, Photo photo)
        {
            
        }

        public Task AddAsync(int loadId, Photo photo)
        {
            return Task.Run(() => Add(loadId, photo));
        }

        public async Task Remove(int photoId)
        {
            
        }

        public async Task Update(Photo photo)
        {
           await Task.Run(()=> _photos.FirstOrDefault(z => z.PhotoId == photo.PhotoId).Description = photo.Description);
        }
    }
}
