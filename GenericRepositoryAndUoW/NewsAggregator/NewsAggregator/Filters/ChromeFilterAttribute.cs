using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace NewsAggregator.Filters
{
    public class ChromeFilterAttribute : Attribute, IResourceFilter
    {
        private readonly int _startHours;
        private readonly int _endHours;

        public ChromeFilterAttribute(int startHours, int endHours)
        {
            _startHours = startHours;
            _endHours = endHours;
        }

        //will be executed after auth-filter but before executing action, action-filters,
        //exception-filters & result-filers
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var dateTime = DateTime.UtcNow;

            if (dateTime.Hour >= _startHours && dateTime.Hour <= _endHours)
            {
                context.HttpContext.Response.Headers.Add("resourse_filter", DateTime.UtcNow.ToString("t"));
            }
            else
            {
                var userAgent = context.HttpContext.Request.Headers["User-Agent"].ToString();
                if (!userAgent.Contains("Chrome/"))
                {

                    //context.Result = new RedirectToActionResult( "Index", "Home", null);
                    context.Result = new ContentResult()
                    {
                        Content = "Browser not supported"
                    };
                }
            }
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            context.HttpContext.Response.Headers.Add("Test", new StringValues("abc"));
        }
    }
}
