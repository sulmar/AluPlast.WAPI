﻿using System;
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
            return $"Hello string {id}";
        }

        [Route("{id:int}")]
        public string Get(int id)
        {
            return $"Hello Number {id}";
        }

        //[Route(@"{id:range(1,3)}")]
        //public IHttpActionResult GetByNumber(string id)
        //{
        //    return Ok($"Hello Range {id}");
        //}


        [Route(@"{id:regex(^ABC\d+$)}")]
        public IHttpActionResult GetRegex(string id)
        {
            return Ok($"Hello Regex {id}");


        }

        [Route("{orderdate:DateTime}")]
        public string Get(DateTime orderdate)
        {
            return $"Hello {orderdate.ToShortDateString()}";
        }


      
    }
}
