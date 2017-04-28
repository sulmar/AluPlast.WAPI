using AluPlast.ControlLoader.Interfaces;
using AluPlast.ControlLoader.MockService;
using AluPlast.Models;
using AluPlast.Models.SearchCriterias;
using AluPlast.Service.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace AluPlast.Service.Controllers
{
    [ValidateModelStateFilter]
   // [AuthenticationFilter("Magazynier")]
    public class LoadsController : ApiController
    {
        private readonly ILoadsService LoadsService;

        //public LoadsController()
        //    : this(new DbLoadsService())
        //{ }

        public LoadsController(ILoadsService loadsService)
        {
            this.LoadsService = loadsService;
        }

        
        


        [Route("api/loads/{date:datetime}")]
        public IHttpActionResult Get(DateTime date)
        {
            //if (Thread.CurrentPrincipal.IsInRole("Magazynier"))
            //{

            //}

            var loads = LoadsService.Get(date);

            if (loads==null || !loads.Any())
            {
                return new CustomActionResult("Brak danych");
            }
            

            return Ok(loads);
        }


        //public IHttpActionResult Head(int id)
        //{
        //    var load = LoadsService.Get(id);

        //    if (load == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok();
        //}

        [AcceptVerbs("GET", "HEAD")]
        public IHttpActionResult Get(int id)
        {
            if (Thread.CurrentPrincipal.IsInRole("Magazynier"))
            {
            }
            
            var load = LoadsService.Get(id);

            if (load == null)
            {
                return NotFound();
            }

            if (this.Request.Method == HttpMethod.Head)
            {
                return Ok();
            }
            else
            {

                return Ok(load);
            }
        }

        public IHttpActionResult Get([FromUri] LoadSearchCriteria criteria)
        {
            var loads = LoadsService.Get(criteria.BeginDate);

            if (loads == null || !loads.Any())
            {
                return new CustomActionResult("Brak danych");
            }


            return Ok(loads);
        }


        public async Task<IHttpActionResult> Post(Load load)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await LoadsService.AddAsync(load);

            // return Created($"http://localhost:9000/api/loads/{load.Id}", load);

            return CreatedAtRoute("DefaultApi", new { id = load.Id }, load);
        }

        public async Task<IHttpActionResult> Put(int id, [FromBody] Load load)
        {
            if (id != load.Id)
            {
                return BadRequest();
            }

            await LoadsService.UpdateAsync(load);

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            LoadsService.Canceled(id, null);

            return Ok();
        }
    }
}
