using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OT.ProjectEaton.CentralResultUnit.Models;
using OT.ProjectEaton.Common.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OT.ProjectEaton.CentralResultUnit.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDeviceMessageService deviceMessageService;

        public HomeController(IDeviceMessageService deviceMessageService)
        {
            this.deviceMessageService = deviceMessageService;
        }

        public async Task<IActionResult> Index()
        {
            var dataCount = (await deviceMessageService.Get()).Count;
            return Ok($"Total message count: {dataCount}");
        }
    }
}
