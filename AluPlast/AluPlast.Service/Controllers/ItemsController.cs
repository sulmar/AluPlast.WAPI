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
    public class ItemsController : BaseController<JednostkaLogistyczna, int, IItemsService>
    {
        public ItemsController(IItemsService service) : base(service)
        {
        }


        [Route("api/loads/{loadId}/items")]
        public async Task<IHttpActionResult> GetByLoad(int loadId)
        {
            var item = await this.Service.GetAsync(loadId);

            return Ok(item);
        }
    }
}
