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
        private readonly ILoadsService LoadsService;

        public LoadsController()
            : this(new DbLoadsService())
        { }

        public LoadsController(ILoadsService loadsService)
        {
            this.LoadsService = loadsService;
        }

        [Route("api/loads/{date:datetime}")]
        public IList<Load> Get(DateTime date)
        {
            var loads = LoadsService.Get(date);

            return loads;
        }
    }
}
