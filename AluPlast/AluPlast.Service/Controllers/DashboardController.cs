using AluPlast.ControlLoader.Interfaces;
using AluPlast.Models.SearchCriterias;
using AluPlast.Service.ActionResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace AluPlast.Service.Controllers
{

    [Route("dashboard")]
    public class DashboardController : ApiController
    {
        private readonly ILoadsService LoadService;

        public DashboardController(ILoadsService loadService)
        {
            this.LoadService = loadService;
        }

        public IHttpActionResult Get()
        {
            var load = LoadService.Get(1);

            return new HtmlActionResult("<b>Hello</b>");
        }
    }
}
