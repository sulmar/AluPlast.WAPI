using AluPlast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluPlast.ControlLoader.Interfaces
{
    public interface ILoadsService
    {
        //IList<Load> Get();

        //Task<IList<Load>> GetAsync();

        IList<Load> Get(DateTime date);

        Task<List<Load>> GetAsync(DateTime date);

        Task Confirm(Load load);

        void Canceled(int loadId, Uzytkownik @operator);

        Task UpdateAsync(Load load);
    }
}
