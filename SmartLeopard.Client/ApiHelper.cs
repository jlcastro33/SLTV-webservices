using SmartLeopard.Models.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http; 
using SmartLeopard.Models;
using RestSharp;

namespace SmartLeopard.Client
{
    public class ApiHelper
    {
        private RestClient restClient;

        public Public Public { get; private set; }
        public Account Account { get; private set; }

        public ApiHelper(string apiUrl)
        {
            restClient = new RestClient(apiUrl);
            Public = new Public(restClient);
            Account = new Account(restClient);
        }
    }


    public abstract class BaseArea
    {
       // protected readonly HttpClient HttpClient;

        protected readonly RestClient restClient;

        protected CancellationToken CancellationToken { get; set; }

        protected BaseArea(RestClient restClient)
        {
          //  HttpClient = httpClient;
            this.restClient = restClient;
        }
    }

    public class Public: BaseArea
    {

        public Public(RestClient restClient) : base(restClient)
        {
        }

        public async Task<HttpStatusCode> CallhomeAsync(DeviceStatus status, string mac, string lang)
        {
            var requestUrl = $"callhome?status={status.GetEnumDescription()}&mac={mac}&lang={lang}";
            var request = new RestRequest(requestUrl);

            return (await restClient.ExecuteGetTaskAsync(request)).StatusCode;
        }

        public async Task<HttpStatusCode> UpdateAsync(string model, string version, string mac, string lang)
        { 
            var requestUrl = $"update?model={model}&v={version}&mac={mac}&lang={lang}";
            var request = new RestRequest(requestUrl);
            return (await restClient.ExecuteGetTaskAsync(request)).StatusCode; 
        }
    }

    public class Account : BaseArea
    {
        public Account(RestClient restClient) : base(restClient)
        {
        }
         
        public async Task<HttpStatusCode> Register(RegistryModel model)
        {
            var request = new RestRequest("registry", Method.POST) {RequestFormat = DataFormat.Json};
            request.AddBody(model);

            var taskCompletionSource = new TaskCompletionSource<IRestResponse>();
            restClient.ExecuteAsync(request, restResponse =>
            {
                if (restResponse.ErrorException != null)
                {
                    const string message = "Error retrieving response.";
                    throw new ApplicationException(message, restResponse.ErrorException);
                }
                taskCompletionSource.SetResult(restResponse);
            });

              

            var result = await taskCompletionSource.Task;
            return result.StatusCode; 
        }
    }
}
