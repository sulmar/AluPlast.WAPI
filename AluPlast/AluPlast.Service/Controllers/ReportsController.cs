using AluPlast.Service.ActionResults;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace AluPlast.Service.Controllers
{
    public class ReportsController : ApiController
    {
        public IHttpActionResult Get()
        {
            var reports = Directory.GetFiles(@"Reports\", "*.rpt")
                .Select(f => Path.GetFileNameWithoutExtension(f));

            return Ok(reports);
        }

        public IHttpActionResult Get(string id)
        {
            var parameters = this.Request.GetQueryNameValuePairs();

            string filename = $@"Reports\{id}.rpt";

            if (!File.Exists(filename))
            {
                return NotFound();
            }

            var rpt = new ReportDocument();
            rpt.Load(filename);

            foreach (var parameter in parameters)
            {
                rpt.SetParameterValue(parameter.Key, parameter.Value);
            }

            var stream = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

            return new StreamActionResult(stream);

        }
    }
}
