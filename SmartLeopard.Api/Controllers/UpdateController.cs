using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SmartLeopard.Bll;
using SmartLeopard.Bll.Services;
using SmartLeopard.Dal.Entities;
using SmartLeopard.Dal.Framework;
using System.Configuration;
using System.IO;
using System.Net.Http.Headers;
using System.Threading;
using System.Web;
using SmartLeopard.Api.Framework;

namespace SmartLeopard.Api.Controllers
{
    [ RoutePrefix("update")] 
    public class UpdateController : ApiController
    {
        private readonly DeviceService _deviceService;

        public UpdateController (DeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpGet]
        public async Task<IHttpActionResult > UpdateAsync(string model, string v, string mac, string lang)
        {
            throw new NullReferenceException();

            var device = await _deviceService.GetAsync(mac) ?? await _deviceService.AddAsync(new Device {Model = model, FirmwareVersion = v, Language = lang, Mac = mac});

            var currentVersion = ConfigurationManager.AppSettings["currentVersion"];

            if (!v.Equals(currentVersion, StringComparison.OrdinalIgnoreCase))
            {
                device.FirmwareVersion = currentVersion;
                await _deviceService.UpdateAsync(device);
                return FirmwareAsync(currentVersion);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult FirmwareAsync(string currentVersion)
        {
            var fileName = HttpContext.Current.Server.MapPath($"~//Firmware//{currentVersion}.zip");
            
            return new FileResult(fileName, "application/zip");
        }
    } 
}
