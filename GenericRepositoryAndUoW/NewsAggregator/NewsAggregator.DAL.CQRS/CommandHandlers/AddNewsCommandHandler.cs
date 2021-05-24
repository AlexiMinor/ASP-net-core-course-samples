using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NewsAggregator.DAL.Core;
using NewsAggregator.DAL.Core.Entities;
using NewsAggregator.DAL.CQRS.Commands;

namespace NewsAggregator.DAL.CQRS.CommandHandlers
{
    class AddNewsCommandHandler : IRequestHandler<AddNewsCommand, int>
    {
        private readonly NewsAggregatorContext _dbContext;

        public AddNewsCommandHandler(NewsAggregatorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(AddNewsCommand request, CancellationToken cancellationToken)
        {
            var news = new News()
            {
                Id = request.Id,
                Article = request.Article,
                Body = request.Body,
                RssSourseId = request.RssSourseId,
                Summary = request.Summary,
                Url = request.Url,
            };
            //add automapper here
            await _dbContext.News.AddAsync(news, cancellationToken);
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
