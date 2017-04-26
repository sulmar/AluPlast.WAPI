using System.Collections.Generic;
using AluPlast.Models;
using System.Threading.Tasks;

namespace AluPlast.Logowanie.Interfaces
{
    public interface IAuthenticationService
    {
        bool IsValid(Uzytkownik uzytkownik, string password);
    }
}
