﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace AluPlast.Service.ActionFilters
{
    public class ExecutionTimeActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var actionName = actionContext.ActionDescriptor.ActionName;

            actionContext.Request.Properties[actionName] = Stopwatch.StartNew();

            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);

            var actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;

            var stopwatch = (Stopwatch) actionExecutedContext.Request.Properties[actionName];
            actionExecutedContext.Response.Headers.Add("execution-time", stopwatch.Elapsed.ToString());

            Trace.WriteLine($"{actionName} elapsed {stopwatch.Elapsed}");

        }
    }
}
