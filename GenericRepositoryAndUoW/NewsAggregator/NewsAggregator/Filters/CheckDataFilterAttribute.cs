using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using NewsAggregator.Core.Services.Interfaces;

namespace NewsAggregator.Filters
{
    public class CheckDataFilterAttribute : Attribute, IAsyncActionFilter
    {
        private readonly INewsService _newsService;

        public CheckDataFilterAttribute(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var isContains = context.HttpContext.Request.QueryString.Value?.Contains("abc");
            if (isContains.GetValueOrDefault())
            {
                context.ActionArguments["hiddenId"] = 42;
                
                context.ActionArguments["news"] = await _newsService.GetNewsBySourseId(null);
            }

            await next();
        }
    }
}