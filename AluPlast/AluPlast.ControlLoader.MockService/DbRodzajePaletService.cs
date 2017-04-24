using System.Collections.ObjectModel;
using System.Data;
using System.Threading.Tasks;
using AluPlast.ControlLoader.Interfaces;
using AluPlast.Models;

namespace AluPlast.ControlLoader.MockService
{
    public class DbRodzajePaletService : IRodzajePaletService
    {
        public readonly ObservableCollection<PaletyRodzaj> RodzajePalet = new ObservableCollection<PaletyRodzaj>
        {
            new PaletyRodzaj()
            {
                Id = 1,
                Nazwa = "PALDrewnianaDuża",
                Opis = ""
            },
            new PaletyRodzaj()
            {
                Id = 2,
                Nazwa = "PALDrewnianaMała",
                Opis = ""
            },
            new PaletyRodzaj()
            {
                Id = 3,
                Nazwa = "PALMetalowaDuża",
                Opis = ""
            }
        };

        public async Task<ObservableCollection<PaletyRodzaj>> GetAsync()
        {
            return await Task.Run(() => RodzajePalet);
        }
    }
}
