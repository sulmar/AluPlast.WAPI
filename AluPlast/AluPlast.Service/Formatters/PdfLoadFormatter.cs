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
    public class PdfLoadFormatter : MediaTypeFormatter
    {

        public PdfLoadFormatter()
        {
            this.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return type == typeof(Load);
        }

        public override async Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            var rpt = new ReportDocument();
            rpt.Load(@"Reports/Load.rpt");

            Load load = value as Load;

            // rpt.SetDatabaseLogon("user", "password");

            rpt.SetParameterValue("LoadId", load.Id);

            var stream = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

            await stream.CopyToAsync(writeStream);
        }
    }
}
