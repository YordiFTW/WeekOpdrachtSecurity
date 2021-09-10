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
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        

        public void OnAuthorization(AuthorizationFilterContext context )
        {
            var user = (User)context.HttpContext.Items["User"];
            if (user == null)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Not Logged In" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }

            else if (user.IsBlocked == true)
            {
                context.Result = new JsonResult(new { message = "You Are Blocked" }) { StatusCode = StatusCodes.Status403Forbidden };

            }

            else if (user.Role == Role.Civilian)
            {
                context.Result = new JsonResult(new { message = "No Privileges" }) { StatusCode = StatusCodes.Status403Forbidden };

            }

            //else if (user.IsAdmin == false)
            //{
            //    // not admin
            //    context.Result = new JsonResult(new { message = "No Admin Privileges" }) { StatusCode = StatusCodes.Status403Forbidden };
            //}
        }
    }
}