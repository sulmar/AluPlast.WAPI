using AluPlast.ControlLoader.Interfaces;
using AluPlast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace AluPlast.Service.Controllers
{
    public abstract class BaseController<TItem, TKey, TService> : ApiController
        where TService : IService<TItem, TKey>
        where TItem : GenericBase<TKey>
    {
        protected readonly TService Service;

        public BaseController(TService service)
        {
            this.Service = service;
        }

        public virtual async Task<IHttpActionResult> Get()
        {
            var item = await Service.GetAsync();

            return Ok(item);
        }

        public virtual async Task<IHttpActionResult> Get(TKey id)
        {
            return Ok(await Service.GetAsync(id));
        }

        [Route("api/{controller}/{id}")]
        public virtual async Task<IHttpActionResult> Put(TKey id, TItem item)
        {
            await Service.UpdateAsync(item);

            return Ok();
        }

        public virtual async Task<IHttpActionResult> Post(TItem item)
        {
            await Service.AddAsync(item);

            return CreatedAtRoute("DefaultApi", new { id = item.Id }, item);
        }

        public virtual async Task<IHttpActionResult> Delete(TKey id)
        {
            await Service.DeleteAsync(id);

            return Ok();
        }

    }
}
