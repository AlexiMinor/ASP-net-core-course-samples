using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NewsAggregator.Core.DataTransferObjects;
using NewsAggregator.Core.Services.Interfaces;
using NewsAggregator.DAL.Core.Entities;
using NewsAggregator.DAL.Repositories.Implementation;
using Serilog;

namespace NewsAggregators.Services.Implementation
{
    public class NewsCqsService : INewsService
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public NewsCqsService(
            IConfiguration configuration, IMapper mapper, IMediator mediator)
        {
            _configuration = configuration;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<NewsDto>> GetNewsBySourseId(Guid? id)
        {
            throw new NotImplementedException();

        }

        public async Task<NewsDto> GetNewsById(Guid id)
        {
            throw new NotImplementedException();

        }

        public async Task<NewsWithRssNameDto> GetNewsWithRssSourseNameById(Guid id)
        {
            throw new NotImplementedException();

        }

        public async Task<IEnumerable<NewsDto>> GetNewsInfoFromRssSourse(RssSourseDto rssSourse)
        {
            throw new NotImplementedException();

        }

        public async Task AddOnlinerNews(NewsDto news)
        {
            throw new NotImplementedException();

        }

        public async Task AddNews(NewsDto news)
        {
           
        }

        public async Task AddRange(IEnumerable<NewsDto> news)
        {
            throw new NotImplementedException();

        }

        public async Task<int> EditNews(NewsDto news)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(NewsDto news)
        {
            throw new NotImplementedException();
        }


    }
}
