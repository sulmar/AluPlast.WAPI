using AluPlast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluPlast.ControlLoader.Interfaces
{


    public interface IService<TItem, TKey>
    {
        Task<IList<TItem>> GetAsync();

        Task<TItem> GetAsync(TKey id);

        Task UpdateAsync(TItem item);

        Task DeleteAsync(TKey id);

        Task AddAsync(TItem item);

    }
    public interface ICustomerService : IService<Customer, int>
    {

    }

    public interface IItemsService : IService<JednostkaLogistyczna, int>
    {
        IList<JednostkaLogistyczna> Get(int loadId);

        Task<string> GetTwrKodAsync(int palId);

    }

    public interface IKontrahenciService : IService<Kontrahent, string>
    {

    }
}
