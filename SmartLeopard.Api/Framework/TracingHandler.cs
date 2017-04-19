using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Newtonsoft.Json;
using SmartLeopard.Bll;
using SmartLeopard.Dal.Entities;
using SmartLeopard.Dal.Framework;

namespace SmartLeopard.Api.Framework
{
    public class TracingHandler : DelegatingHandler
    {
        private readonly DataService<Trace> _traceService;

        public TracingHandler(DataService<Trace> traceService)
        {
            _traceService = traceService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var start = DateTime.Now;
            var trace = new Trace
            {
                EndpointWithoutParams = request.RequestUri.AbsolutePath,
                EndpointParams = request.RequestUri.Query,
                Method = request.Method.ToString(),
                RequestContent = JsonConvert.SerializeObject(request.Content)
            };

            var response = await base.SendAsync(request, cancellationToken);

            trace.ResponseStatusCode = response.StatusCode.ToString();
            trace.ResponseContent = (response.Content?.Headers?.ContentLength ?? 0) > 1000 
                ? $"ContentLength:{response.Content.Headers.ContentLength }" 
                : JsonConvert.SerializeObject(response.Content);
            trace.ProcessTimeMls = Math.Round((DateTime.Now - start).TotalMilliseconds,0);


           await _traceService.AddAsync(trace);
            return response;
        }
    }
}