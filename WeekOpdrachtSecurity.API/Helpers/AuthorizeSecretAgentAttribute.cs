using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WeekOpdrachtSecurity.API.Entities;
using WeekOpdrachtSecurity.API.Enums;

namespace WeekOpdrachtSecurity.API.Helpers
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class/*, Inherited = true, AllowMultiple = true*/)]
    public class AuthorizeSecretAgentAttribute : Attribute, IAuthorizationFilter
    {


        

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User)context.HttpContext.Items["User"];

            if (user == null || user.Role != Role.SecretAgent)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Insuficient SecretAgent Privliges" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}