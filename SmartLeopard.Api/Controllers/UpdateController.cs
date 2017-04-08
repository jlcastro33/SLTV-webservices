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

namespace SmartLeopard.Api.Controllers
{
    [RoutePrefix("update")]
    public class UpdateController : ApiController
    {
        private readonly DeviceService _deviceService;

        public UpdateController (DataService<Device> deviceService)
        {
            _deviceService = (DeviceService) deviceService;
        }

        [HttpGet]
        public async Task<IHttpActionResult > UpdateAsync(string model, string v, string mac, string lang)
        {

            var device = await _deviceService.GetAsync(mac) ?? await _deviceService.AddAsync(new Device {Model = model, FirmwareVersion = v, Language = lang, Mac = mac});

            if (await _deviceService.OldVersion(device))
            {
                device.FirmwareVersion = v;
                await _deviceService.UpdateAsync(device);
                return await NewVersionAsync();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        public async Task<IHttpActionResult> NewVersionAsync()
        {

            throw new NotImplementedException();
        } 
    }
}
