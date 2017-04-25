using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace AluPlast.Service.ActionResults
{
    public class StreamActionResult : IHttpActionResult
    {
        private readonly Stream Stream;

        public StreamActionResult(Stream stream)
        {
            this.Stream = stream;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);

            response.Content = new StreamContent(Stream);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");

            return Task.FromResult(response);
        }
    }
}
