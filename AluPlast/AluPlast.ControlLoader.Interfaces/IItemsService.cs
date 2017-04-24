using AluPlast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluPlast.ControlLoader.Interfaces
{
    public interface IItemsService
    {
        Task<IList<JednostkaLogistyczna>> GetAsync(int loadId);

        IList<JednostkaLogistyczna> Get(int loadId);

        Task<string> GetTwrKodAsync(int palId);

        Task Update(JednostkaLogistyczna item);

        Task AddAsync(int loadId, JednostkaLogistyczna item);
        Task Remove(int itemId, string kontroler);
    }
}
