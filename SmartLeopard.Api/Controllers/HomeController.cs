using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartLeopard.Bll;
using SmartLeopard.Bll.Services;
using SmartLeopard.Dal.Entities;
using SmartLeopard.Dal.Repositories;
using SmartLeopard.Models.Enums;

namespace SmartLeopard.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly DeviceService _deviceService;
        private readonly UserService _userService;

        public HomeController(DataService<Device> deviceService, DataService<User> userService)
        {
            _deviceService = (DeviceService) deviceService;
            _userService = (UserService) userService;
        }


        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            _deviceService.AddAsync(new Device {Mac = Guid.NewGuid().ToString(), Status = DeviceStatus.Booting});
            _userService.AddAsync(new User() {Name = "name", Email = "emaikk"});

            return View();
        }
    }
}
