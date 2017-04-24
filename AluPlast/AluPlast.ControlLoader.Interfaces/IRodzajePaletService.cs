using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AluPlast.Models;

namespace AluPlast.ControlLoader.Interfaces
{
    public interface IRodzajePaletService
    {
        Task<ObservableCollection<PaletyRodzaj>> GetAsync();
    }
}
