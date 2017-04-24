using AluPlast.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluPlast.ControlLoader.Interfaces
{
    public interface IPhotosService
    {
        ObservableCollection<Photo> Get(int loadId);

        Task<ObservableCollection<Photo>> GetAsync(int loadId);
        Task<ObservableCollection<Stream>> GetStreamsAsync(int loadId);
        Task<Stream> GetSingleAsync(int loadId, int photoId);

        void Add(int loadId, Photo photo);

        Task AddAsync(int loadId, Photo photo);

        Task Remove(int photoId);
        Task Update(Photo photo);
    }
}
