using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SmartLeopard.Bll;
using SmartLeopard.Bll.Resources;
using SmartLeopard.Bll.Services;
using SmartLeopard.Dal.Entities;
using SmartLeopard.Dal.Framework;
using SmartLeopard.Models;

namespace SmartLeopard.Api.Controllers
{ 
    public class AccountController : ApiController
    {
        private readonly IDataService<User> _userService;
        private readonly DeviceService _deviceService;

        public AccountController(IDataService<Device> deviceService, IDataService<User> userService)
        {
            _userService = userService;
            _deviceService =  (DeviceService) deviceService;
        }

        [HttpPost, Route("registry")]
        public async Task<IHttpActionResult> RegistryAsync(RegistryModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var device = await _deviceService.GetAsync(model.Mac) ?? await _deviceService.AddAsync(new Device {Language = model.Lang, Mac = model.Mac});
            device.Users.Add(AutoMapper.Mapper.Map<User>(model));
            await _deviceService.UpdateAsync(device);

            return Ok();
        }

        [HttpPost, Route("login")]
        public async Task<IHttpActionResult> LoginAsync(LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!(await _userService.GetAsync(u => u.Email == model.Email && u.Password == model.Password)).Any()) 
                return Content(HttpStatusCode.Forbidden, Resource.GetString("Unknown_Username_or_bad_password", model.Lang));

            return Ok(model.Mac);
        } 
    }
}
