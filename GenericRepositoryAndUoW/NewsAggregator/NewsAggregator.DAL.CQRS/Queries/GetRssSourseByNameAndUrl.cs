using System;
using System.Collections.Generic;
using MediatR;
using NewsAggregator.Core.DataTransferObjects;

namespace NewsAggregator.DAL.CQRS.Queries
{
    public class GetRssSourseByNameAndUrlQuery : IRequest<IEnumerable<RssSourseDto>>
    {
        public string Name { get; set; }
        public string Url { get; set; }

        //public GetRssSourseByNameAndUrlQuery(string name, string url)
        //{
        //    Name = name;
        //    Url = url;
        //}
    }
}