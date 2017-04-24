using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AluPlast.Service.MessageHandlers
{
    public class TraceMessageHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Trace.WriteLine($"{request.Method} : {request.RequestUri}");

            var response = await base.SendAsync(request, cancellationToken);

            Trace.WriteLine($"{response.StatusCode}");

            return response;
        }
    }
}
