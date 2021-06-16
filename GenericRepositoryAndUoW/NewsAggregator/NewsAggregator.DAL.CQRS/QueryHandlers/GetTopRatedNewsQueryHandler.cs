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
    public class GetTopRatedNewsQueryHandler : IRequestHandler<GetTopRatedNewsQuery, List<NewsDto>>
    {
        private readonly NewsAggregatorContext _dbContext;
        private readonly IMapper _mapper;

        public GetTopRatedNewsQueryHandler(NewsAggregatorContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<NewsDto>> Handle(GetTopRatedNewsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.News.Where(news => news.Body != null).Take(3)
                    .Select(news => _mapper.Map<NewsDto>(news))
                    .ToListAsync(cancellationToken);
        }
    }
}