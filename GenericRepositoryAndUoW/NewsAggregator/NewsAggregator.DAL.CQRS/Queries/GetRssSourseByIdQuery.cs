using System;
using MediatR;
using NewsAggregator.Core.DataTransferObjects;

namespace NewsAggregator.DAL.CQRS.Queries
{
    public class GetRssSourseByIdQuery : IRequest<RssSourseDto>
    {
        public Guid Id { get; set; }

    }
}