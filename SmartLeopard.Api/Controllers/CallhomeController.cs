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
using SmartLeopard.Models.Enums;

namespace SmartLeopard.Api.Controllers
{
    [RoutePrefix("callhome")]
    public class CallhomeController : ApiController
    {
        private readonly DeviceService _deviceService;

        public CallhomeController(DataService<Device> deviceService)
        {
            _deviceService = (DeviceService) deviceService;
        }

        [HttpGet]
        public async Task<IHttpActionResult > UpdateStatusAsync(string status, string mac, string lang)
        { 
            var device = await _deviceService.GetAsync(mac) ?? await _deviceService.AddAsync(new Device {Language = lang, Mac = mac}); 
            device.Status = EnumHelper.ToEnum<DeviceStatus>(status); 
            await _deviceService.UpdateAsync(device);

            return Ok();
        } 
    }
}
