using System;
using System.Collections.Generic;
using MediatR;
using NewsAggregator.Core.DataTransferObjects;

namespace NewsAggregator.DAL.CQRS.Queries
{
    public class GetAllExistingNewsUrlsQuery: IRequest<List<string>>
    {
    }
}