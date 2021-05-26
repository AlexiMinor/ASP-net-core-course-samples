using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NewsAggregator.Core.DataTransferObjects;
using NewsAggregator.DAL.Core;
using NewsAggregator.DAL.CQRS.Queries;

namespace NewsAggregator.DAL.CQRS.QueryHandlers
{
    public class GetAllExistingNewsUrlsQueryHandler : IRequestHandler<GetAllExistingNewsUrlsQuery, List<string>>
    {
        private readonly NewsAggregatorContext _dbContext;

        public GetAllExistingNewsUrlsQueryHandler(NewsAggregatorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<string>> Handle(GetAllExistingNewsUrlsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.News.Select(news => news.Url)
                .ToListAsync(cancellationToken);
        }
    }
}