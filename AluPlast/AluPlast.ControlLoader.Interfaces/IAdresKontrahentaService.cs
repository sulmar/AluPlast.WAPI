using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AluPlast.Models;

namespace AluPlast.ControlLoader.Interfaces
{
    public interface IAdresKontrahentaService
    {
        ObservableCollection<AdresKontrahenta> Get();
        Task<ObservableCollection<AdresKontrahenta>> GetAsync();
        Task AddAsync(AdresKontrahenta adres);
    }
}
