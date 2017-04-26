using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AluPlast.Logowanie.Interfaces;
using AluPlast.Models;
using AluPlast.Models.Enums;

namespace AluPlast.Logowanie.MockService
{
    public class DbUsersService : IUsersService
    {
        public async Task<List<Uzytkownik>> GetAsync(Program programId)
        {
            var users = new List<Uzytkownik>();

            var user = new Uzytkownik();
            user.Id = 1;
            user.NickName = "MDZ";
            user.FirstName = "Maciej";
            user.LastName = "Dziadowiec";
            user.Password = "2222";
            users.Add(user);

            var user2 = new Uzytkownik
            {
                Id = 2,
                NickName = "MIKE",
                FirstName = "Michał`",
                LastName = "Kazmierczak",
                Password = "7777"
            };
            users.Add(user2);


            var users2 = users.OrderBy(z => z.FullName);
            var userCollection = new List<Uzytkownik>(users2);
            return await Task.Run(() => userCollection);
        }
    }
}
