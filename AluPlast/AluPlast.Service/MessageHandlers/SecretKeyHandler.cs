using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AluPlast.Service.MessageHandlers
{
    public class SecretKeyHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            IEnumerable<string> secretKeys;

            if (request.Headers.TryGetValues("Secret-Key", out secretKeys))
            {
                if (secretKeys.Any(s=>s == "12345"))
                {
                    return await base.SendAsync(request, cancellationToken);
                }
            }

            var response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);

            return response;
        }
    }
}
