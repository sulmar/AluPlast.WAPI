using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AluPlast.Service.MessageHandlers
{
    public class FormatMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var parameters = request.GetQueryNameValuePairs();

            var valueformat = parameters.FirstOrDefault(p => p.Key == "format");

            if (valueformat.Value!=null)
            {
                request.Headers.Add("Accept", valueformat.Value);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}
