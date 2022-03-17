﻿using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace ASP.NET_Identity.Extensions
{
    public class AuditoriaFilter : IActionFilter
    {
        private readonly ILogger _logger;
        public AuditoriaFilter(ILogger logger)
        {
            _logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext context) { }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                string message = context.HttpContext.User.Identity.Name + " Acessou: " +
                              context.HttpContext.Request.GetDisplayUrl();
                _logger.LogInformation(message);
            }
        }
    }
}
