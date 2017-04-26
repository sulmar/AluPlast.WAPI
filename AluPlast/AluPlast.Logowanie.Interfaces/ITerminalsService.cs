using System.Threading.Tasks;
using AluPlast.Models;

namespace AluPlast.Logowanie.Interfaces
{
    public interface ITerminalsService
    {
        Task<Terminal> GetAsync(string deviceId);
    }
}
