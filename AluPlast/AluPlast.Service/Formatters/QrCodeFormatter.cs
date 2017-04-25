using AluPlast.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace AluPlast.Service.Formatters
{
    public class QrCodeFormatter : MediaTypeFormatter
    {
        public QrCodeFormatter()
        {
            this.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("image/png"));
        }

        public override bool CanReadType(Type type)
        {
            return true;
        }

        public override bool CanWriteType(Type type)
        {
            return type == typeof(Load);
        }

        public override async Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {

            var load = value as Load;

            var uri = $"http://chart.apis.google.com/chart?cht=qr&chs=300x300&chl={load.Id}";

            using(var client = new WebClient())
            {
                var data = await client.DownloadDataTaskAsync(uri);

                await writeStream.WriteAsync(data, 0, data.Length);
            }

            // return base.WriteToStreamAsync(type, value, writeStream, content, transportContext);
        }
    }
}
