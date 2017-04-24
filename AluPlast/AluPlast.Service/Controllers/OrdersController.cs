using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace AluPlast.Service.Controllers
{
    [RoutePrefix("api/zamowienia")]
    public class OrdersController : ApiController
    {
        [Route()]
        public string Get()
        {
            Console.WriteLine(this.Request);

            return "Hello Web Api";
        }

        [Route("{id}")]
        public string Get(string id)
        {
            return $"Hello {id}";
        }

        [Route("{id:int}")]
        public string Get(int id)
        {
            return $"Hello {id}";
        }

        [Route("{orderdate:DateTime}")]
        public string Get(DateTime orderdate)
        {
            return $"Hello {orderdate.ToShortDateString()}";
        }


      
    }
}
