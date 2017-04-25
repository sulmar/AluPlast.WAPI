using AluPlast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;
using CrystalDecisions.CrystalReports.Engine;

namespace AluPlast.Service.Formatters
{
    public class PdfLoadsFormatter : MediaTypeFormatter
    {

        public PdfLoadsFormatter()
        {
            this.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return type == typeof(IList<Load>);
        }

        public override async Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            var rpt = new ReportDocument();
            rpt.Load(@"Reports/Loads.rpt");

            // rpt.SetDatabaseLogon("user", "password");

            var stream = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

            await stream.CopyToAsync(writeStream);

          //  await base.WriteToStreamAsync(type, value, writeStream, content, transportContext);
        }
    }
}
