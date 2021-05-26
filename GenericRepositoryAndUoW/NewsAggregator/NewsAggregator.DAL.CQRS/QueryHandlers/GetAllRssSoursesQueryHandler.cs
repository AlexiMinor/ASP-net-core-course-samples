using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NewsAggregator.Core.DataTransferObjects;
using NewsAggregator.DAL.Core;
using NewsAggregator.DAL.CQRS.Queries;

namespace NewsAggregator.DAL.CQRS.QueryHandlers
{
    public class GetAllRssSoursesQueryHandler  : IRequestHandler<GetAllRssSoursesQuery, IEnumerable<RssSourseDto>>
    {
        private readonly NewsAggregatorContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllRssSoursesQueryHandler(NewsAggregatorContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<IEnumerable<RssSourseDto>> Handle(GetAllRssSoursesQuery request, CancellationToken cancellationToken)
        {

            return await _dbContext.RssSources
                .Select(sourse => _mapper.Map<RssSourseDto>(sourse))
                .ToListAsync(cancellationToken);
        }
    }
}