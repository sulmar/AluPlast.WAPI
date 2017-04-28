using AluPlast.ControlLoader.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using AluPlast.Models;
//using AluPlast.Models.SearchCriterias;
using System.Net.Http;
using System.Net.Http.Formatting;
using Newtonsoft.Json;

namespace AluPlast.WPFClient.Services
{
    //public class RestApiLoadsService : ILoadsService
    //{
    //    public Task AddAsync(Load load)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Canceled(int loadId, Uzytkownik @operator)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task Confirm(Load load)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IList<Load> Get(LoadSearchCriteria criteria)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Load Get(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IList<Load> Get(DateTime date)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public async Task<List<Load>> GetAsync(DateTime date)
    //    {
    //        var uri = $"loads/{date}";

    //        var formatter = new JsonMediaTypeFormatter
    //        {
    //            SerializerSettings = new JsonSerializerSettings
    //            {
    //                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
    //                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
    //            }
    //        };

    //        var formatters = new[] { formatter };


    //        var client = new HttpClient();
    //        client.BaseAddress = new Uri(@"http://localhost:9000");

    //        var response = await client.GetAsync(uri);

    //        var loads = await response.Content.ReadAsAsync<IList<Load>>(formatters);

    //        return loads.ToList();
    //    }

    //    public Task UpdateAsync(Load load)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
