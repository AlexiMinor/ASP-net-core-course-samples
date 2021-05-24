using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewsAggregator.Core.DataTransferObjects;

namespace NewsAggregator.Core.Services.Interfaces
{
    public interface IRssSourseService
    {
        Task<IEnumerable<RssSourseDto>> GetAllRssSources();
        Task<RssSourseDto> GetRssSourseById(Guid id);
        Task<IEnumerable<RssSourseDto>> GetRssSoursesByNameAndUrl(string name, string url);
    }
}
