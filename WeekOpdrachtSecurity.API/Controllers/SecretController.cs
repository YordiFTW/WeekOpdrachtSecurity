using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeekOpdrachtSecurity.API.Entities;
using WeekOpdrachtSecurity.API.Models;
using WeekOpdrachtSecurity.API.Services;

namespace WeekOpdrachtSecurity.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecretController : ControllerBase
    {
        private ISecretService _userService;

        public SecretController(ISecretService userService)
        {
            _userService = userService;
        }



        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAllSecrets();
            return Ok(users);
        }
    }
}