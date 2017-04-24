using AluPlast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluPlast.ControlLoader.Interfaces
{
    public interface IAuthenticationService
    {
        bool IsValid(Uzytkownik uzytkownik, string password);
    }
}
