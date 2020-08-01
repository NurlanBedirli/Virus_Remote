using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Virus_Remote.Data;
using Virus_Remote.Models;

namespace Virus_Remote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemoteAPIController : ControllerBase
    {
        private readonly RemoteDbContext  _dbContext;

        public RemoteAPIController(RemoteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await Task.Delay(0);
            return Ok("succes");
        }

        public async Task<IActionResult> Add(User user)
        {
            if(!await _dbContext.Users.AnyAsync(x=> x.MACAddress == user.MACAddress))
            {
                user.CreatedAt = DateTime.Now;
                _dbContext.Users.Add(user);
                 await _dbContext.SaveChangesAsync();
                return Ok(true);
            }
            return Ok(false);
        }
    }
}