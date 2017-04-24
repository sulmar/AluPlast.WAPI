using AluPlast.ControlLoader.Interfaces;
using AluPlast.ControlLoader.MockService;
using AluPlast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace AluPlast.Service.Controllers
{
    public class LoadsController : ApiController
    {
        private ILoadsService LoadsService = new DbLoadsService();

        public IList<Load> Get(DateTime id)
        {
            var loads = LoadsService.Get(id);

            return loads;
        }
    }
}
