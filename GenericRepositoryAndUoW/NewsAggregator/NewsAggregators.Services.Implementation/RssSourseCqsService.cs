using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NewsAggregator.Core.DataTransferObjects;
using NewsAggregator.Core.Services.Interfaces;
using NewsAggregator.DAL.CQRS.Queries;
using NewsAggregator.DAL.Repositories.Implementation;

namespace NewsAggregators.Services.Implementation
{
    public class RssSourseCqsService : IRssSourseService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public RssSourseCqsService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }


        public async Task<IEnumerable<RssSourseDto>> GetAllRssSources()
        {
            throw new NotImplementedException();

        }


        public async Task<RssSourseDto> GetRssSourseById(Guid id)
        {
            var getRssSourseByIdQuery = new GetRssSourseByIdQuery {Id = id};
            var result = await _mediator.Send(getRssSourseByIdQuery);
            return result;
        }

      
        public async Task<IEnumerable<RssSourseDto>> GetRssSoursesByNameAndUrl(string name, string url)
        {
            var query = new GetRssSourseByNameAndUrlQuery() { Name = name, Url = url};
            var result = await _mediator.Send(query);
            return result;
        }
    }
}
