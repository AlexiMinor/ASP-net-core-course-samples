using System;
using MediatR;

namespace NewsAggregator.DAL.CQRS.Commands
{
    public class AddNewsCommand : IRequest<int>
    {
        public Guid Id { get; set; }
        public string Article { get; set; }
        public string Url { get; set; }
        public string Body { get; set; }
        public string Summary { get; set; }
        public Guid RssSourseId { get; set; }
    }
}