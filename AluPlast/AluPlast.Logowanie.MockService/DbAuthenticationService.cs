using AluPlast.Logowanie.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AluPlast.Models;

namespace AluPlast.Logowanie.MockService
{
    public class DbAuthenticationService : IAuthenticationService
    {

        public bool IsValid(Uzytkownik uzytkownik, string password)
        {
            return uzytkownik.Password == password;
        }
    }
}
