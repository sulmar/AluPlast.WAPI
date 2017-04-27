using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace AluPlast.Service.ActionResults
{
    public class HtmlActionResult : IHttpActionResult
    {
        private readonly string html;

        public HtmlActionResult(string html)
        {
            this.html = html;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);

            response.Content = new StringContent(html);

            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/html");

            return Task.FromResult(response);

        }
    }
}
