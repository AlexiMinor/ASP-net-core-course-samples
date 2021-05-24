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
    public class GetRssSourseByNameAndUrlQueryHandler : IRequestHandler<GetRssSourseByNameAndUrlQuery, IEnumerable<RssSourseDto>>
    {
        private readonly NewsAggregatorContext _dbContext;
        private readonly IMapper _mapper;

        public GetRssSourseByNameAndUrlQueryHandler(NewsAggregatorContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RssSourseDto>> Handle(GetRssSourseByNameAndUrlQuery request, CancellationToken cancellationToken)
        {
            return 
                (await _dbContext.RssSources
                    .Where(sourse => sourse.Name.Equals(request.Name) && sourse.Url.Equals(request.Url))
                    .ToListAsync(cancellationToken)).Select(sourse => _mapper.Map<RssSourseDto>(sourse));
        }
    }
}