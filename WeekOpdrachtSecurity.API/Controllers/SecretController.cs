using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WeekOpdrachtSecurity.API.Entities;
using WeekOpdrachtSecurity.API.Helpers;
using WeekOpdrachtSecurity.API.Models;
using WeekOpdrachtSecurity.API.Services;


namespace WeekOpdrachtSecurity.API.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class SecretController : ControllerBase
    {
        private ISecretService _secretService;
        

        public SecretController(ISecretService secretService)
        {
            _secretService = secretService;
           
        }



        [AuthorizeFBI]
        [HttpGet]
        public IActionResult GetAll()
        {
            var secret = _secretService.GetAllSecrets();
            return Ok(secret);
        }

        [AuthorizeGovermentEmployee]
        [HttpGet("GetGovermentEmployeeSecrets")]
        public IActionResult GetGovermentEmployeeSecrets()
        {
            var secret = _secretService.GetAllSecrets();
            return Ok(secret.Where(o => o.Classification == Enums.SecretClassificationEnum.gevoeligeinformatie));
        }

        [AuthorizeSecretAgent]
        [HttpGet("GetSecretAgentSecrets")]
        public IActionResult GetSecretAgentSecrets()
        {
            var secret = _secretService.GetAllSecrets();
            return Ok(secret.Where(o => o.Classification == Enums.SecretClassificationEnum.staatsgeheim));
        }

        [AuthorizeFBI]
        [HttpGet("GetFBISecrets")]
        public IActionResult GetFBISecrets()
        {
            var secret = _secretService.GetAllSecrets();
            return Ok(secret.Where(o => o.Classification == Enums.SecretClassificationEnum.topsecret));
        }
    }
}