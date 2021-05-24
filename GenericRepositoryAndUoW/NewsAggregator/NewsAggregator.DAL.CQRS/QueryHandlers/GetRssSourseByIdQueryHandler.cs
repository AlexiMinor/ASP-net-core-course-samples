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
    public class GetRssSourseByIdQueryHandler  : IRequestHandler<GetRssSourseByIdQuery, RssSourseDto>
    {
        private readonly NewsAggregatorContext _dbContext;
        private readonly IMapper _mapper;

        public GetRssSourseByIdQueryHandler(NewsAggregatorContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<RssSourseDto> Handle(GetRssSourseByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<RssSourseDto>(
                await _dbContext.RssSources
                    .FirstOrDefaultAsync(sourse => sourse.Id.Equals(request.Id), 
                        cancellationToken));
        }
    }
}