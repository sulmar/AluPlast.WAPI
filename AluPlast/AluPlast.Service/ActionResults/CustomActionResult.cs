using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace AluPlast.Service
{
    public class CustomActionResult : IHttpActionResult
    {
        private readonly string ReasonPhrase;

        public CustomActionResult(string reasonPhrase)
        {
            this.ReasonPhrase = reasonPhrase;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.NoContent);

            response.ReasonPhrase = ReasonPhrase;

            return Task.FromResult(response);
        }
    }
}
