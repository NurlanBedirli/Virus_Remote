using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Virus_Remote.Core.Filters
{
    public class Authorize : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
                await next();
            else
            {
                context.Result = new RedirectToRouteResult(new
                {
                    controller = "Account",
                    action = "Login"
                });
            }
        }
    }
}
