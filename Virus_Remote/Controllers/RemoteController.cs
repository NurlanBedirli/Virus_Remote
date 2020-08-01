using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Virus_Remote.Core.Filters;

namespace Virus_Remote.Controllers
{
    [Authorize]
    public class RemoteController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
                return View();
        }
    }
}