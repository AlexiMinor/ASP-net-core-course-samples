using System.Collections.Generic;
using MediatR;
using NewsAggregator.Core.DataTransferObjects;

namespace NewsAggregator.DAL.CQRS.Queries
{
    public class GetTopRatedNewsQuery : IRequest<List<NewsDto>>
    {
        
    }
}