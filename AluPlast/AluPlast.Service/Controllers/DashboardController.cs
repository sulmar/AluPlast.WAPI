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
        private readonly IItemsService ItemsService;

        public DashboardController(ILoadsService loadService, IItemsService itemsService)
        {
            this.LoadService = loadService;
            this.ItemsService = itemsService;
        }

        public IHttpActionResult Get()
        {
            var model = LoadService.Get(1);

            model.Items = ItemsService.Get(model.Id);

            // return new HtmlActionResult("<b>Hello</b>");

            return new RazorActionResult("Dashboard", model);
        }
    }
}
