using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace AluPlast.Service.Controllers
{
    public class OrdersController : ApiController
    {

        public string Get()
        {
            Console.WriteLine(this.Request);

            return "Hello Web Api";
        }

        public string Get(int id)
        {
            return $"Hello {id}";
        }

        public void Post([FromBody] string text)
        {

        }

        //public string Get(DateTime id)
        //{
        //    return $"Hello {id.ToShortDateString()}";
        //}
    }
}
