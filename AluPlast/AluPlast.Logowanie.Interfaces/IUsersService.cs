using System.Collections.Generic;
using AluPlast.Models;
using System.Threading.Tasks;
using AluPlast.Models.Enums;

namespace AluPlast.Logowanie.Interfaces
{
    public interface IUsersService
    {
        Task<List<Uzytkownik>> GetAsync(Program programId);


    }
}
