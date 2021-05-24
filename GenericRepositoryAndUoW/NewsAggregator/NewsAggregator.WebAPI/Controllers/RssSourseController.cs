using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsAggregator.Core.DataTransferObjects;
using NewsAggregator.Core.Services.Interfaces;

namespace NewsAggregator.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RssSourseController : ControllerBase
    {
        private readonly IRssSourseService _sourseService;

        public RssSourseController(IRssSourseService rssSourseService)
        {
            _sourseService = rssSourseService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var sourse = await _sourseService.GetRssSourseById(id);

            return Ok(sourse);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string name, string url)
        {
            var sources = await _sourseService.GetAllRssSources();
            //todo must be in service
            if (!string.IsNullOrEmpty(name))
            {
                sources = sources.Where(dto => dto.Name.Contains(name));
            }
            if (!string.IsNullOrEmpty(url))
            {
                sources = sources.Where(dto => dto.Url.Contains(url));
            }
            //
            return Ok(sources);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RssSourseDto request)
        {
            //var sources = await _sourseService.AddRssSourse(request);

            return Ok();
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, [FromBody] RssSourseDto value)
        //{
        //    var sources = await _sourseService.GetAllRssSources();

        //    return Ok(sources);
        //}

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] string value)
        {
            var sources = await _sourseService.GetAllRssSources();

            return Ok(sources);
        }
    }
}
