using AluPlast.Models;
using RazorEngine;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace AluPlast.Service.ActionResults
{
    public class RazorActionResult : IHttpActionResult
    {
        private const string ViewDirectory = @"Views";

        private readonly string _viewname;
        private readonly dynamic _model;

        public RazorActionResult(string viewname, dynamic model)
        {
            this._viewname = viewname;
            this._model = model;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            var template = LoadTemplate(_viewname);

            var result = Engine.Razor.RunCompile(template, "templateNameInTheCache", typeof(Load), (object) _model);

            response.Content = new StringContent(result);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return Task.FromResult(response);
        }

        private static string LoadTemplate(string viewname)
        {
            var filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ViewDirectory, viewname + ".cshtml");

            if (!File.Exists(filename))
                return string.Empty;

            var view = File.ReadAllText(filename);
            return view;
        }
    }
}
