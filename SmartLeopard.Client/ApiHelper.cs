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
using System.Threading.Tasks;

namespace SmartLeopard.Client
{
    public class ApiHelper
    {
        private HttpClient httpClient;

        public Public Public { get; private set; }

        public ApiHelper(string apiUrl)
        {
            httpClient = new HttpClient {BaseAddress = new Uri(apiUrl)};
            Public = new Public(httpClient);
        }
    }

    public class Public
    {
        private readonly HttpClient _httpClient;

        public Public(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpStatusCode> CallhomeAsync(DeviceStatus status, string mac, string lang)
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var requestUrl = $"callhome?status={status.GetEnumDescription()}&mac={mac}&lang={lang}";
            return (await _httpClient.GetAsync(requestUrl)).StatusCode;
        }

        public async Task<HttpStatusCode> UpdateAsync()
        { 
            var requestUrl = $"update?model=SLTV1&v=SLTV1.2&mac=AABBCCDDFF11&lang=es-es";
            var s = await _httpClient.GetAsync(requestUrl);
            using (var fileStream = new FileStream($"C:/Work/Max/FL/Smart Leopard/SLTV-webservices/SmartLeopard.Client.Test/test/{Guid.NewGuid()}.zip", FileMode.Create, FileAccess.Write))
            {
                (await s.Content.ReadAsStreamAsync()).CopyTo(fileStream);
            }


            //using (var ms = new MemoryStream())
            //{
            //    using (var zipArchive = new ZipArchive((await s.Content.ReadAsStreamAsync()), ZipArchiveMode.Create, false))
            //    {
            //        zipArchive.
            //            var entry = zipArchive.CreateEntry(attachment.FileName, CompressionLevel.Fastest);
            //            using (var entryStream = entry.Open())
            //            {
            //                attachment.InputStream.CopyTo(entryStream);
            //            }
                    
            //    } 
//]

            return s.StatusCode;
        }
    }
}
