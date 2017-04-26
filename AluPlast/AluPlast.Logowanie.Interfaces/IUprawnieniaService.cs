using System.Collections.Generic;
using System.Threading.Tasks;
using AluPlast.Models;

namespace AluPlast.Logowanie.Interfaces
{
    public interface IUprawnieniaService
    {
        Task<List<Uprawnienie>> GetUprawnieniaUsera(int userId);
    }
}
