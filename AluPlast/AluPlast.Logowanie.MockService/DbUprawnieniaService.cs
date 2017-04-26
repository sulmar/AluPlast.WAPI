using System.Collections.Generic;
using System.Threading.Tasks;
using AluPlast.Logowanie.Interfaces;
using AluPlast.Models;
using AluPlast.Models.Enums;

namespace AluPlast.Logowanie.MockService
{
    public class DbUprawnieniaService : IUprawnieniaService
    {
        public async Task<List<Uprawnienie>> GetUprawnieniaUsera(int userId)
        {
            var uprawnieniaUsera = new List<Uprawnienie>();

            var uprawnienie = new Uprawnienie();
            uprawnienie.Program = Program.KontrolaZaladunku;
            uprawnieniaUsera.Add(uprawnienie);

            var uprawnienie2 = new Uprawnienie();
            uprawnienie2.Program = Program.ZmianaLokalizacji;
            uprawnieniaUsera.Add(uprawnienie2);

            return await Task.FromResult<List<Uprawnienie>>(uprawnieniaUsera);

        }
    }
}
