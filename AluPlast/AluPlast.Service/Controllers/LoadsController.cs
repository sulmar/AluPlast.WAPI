﻿using AluPlast.ControlLoader.Interfaces;
using AluPlast.ControlLoader.MockService;
using AluPlast.Models;
using AluPlast.Models.SearchCriterias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        public IHttpActionResult Get(DateTime date)
        {
            var loads = LoadsService.Get(date);

            if (loads==null || !loads.Any())
            {
                return new CustomActionResult("Brak danych");
            }
            

            return Ok(loads);
        }

        public IHttpActionResult Get(int id)
        {
            var load = LoadsService.Get(id);

            if (load == null)
            {
                return NotFound();
            }

            return Ok(load);
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
