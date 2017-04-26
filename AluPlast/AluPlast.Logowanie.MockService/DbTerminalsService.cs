using System;
using System.Data;
using System.Threading.Tasks;
using AluPlast.Logowanie.Interfaces;
using AluPlast.Models;

namespace AluPlast.Logowanie.MockService
{
    public class DbTerminalsService : ITerminalsService
    {
        public async Task<Terminal> GetAsync(string deviceId)
        {
            var terminal = new Terminal()
            {
                Id = 9,
                DeviceId = deviceId
            };
            return await Task.Run(() => terminal);
        }
    }
}
