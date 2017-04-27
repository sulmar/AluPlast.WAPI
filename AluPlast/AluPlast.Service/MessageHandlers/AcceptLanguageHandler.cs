using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AluPlast.Service.MessageHandlers
{
    public class AcceptLanguageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var language = request.Headers.AcceptLanguage.FirstOrDefault();

            if (language!=null)
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language.Value);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}
