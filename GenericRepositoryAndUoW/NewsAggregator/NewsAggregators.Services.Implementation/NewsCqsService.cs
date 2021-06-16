using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using NewsAggregator.Core.DataTransferObjects;
using NewsAggregator.Core.Services.Interfaces;
using NewsAggregator.DAL.CQRS.Queries;

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

            return null;
        }

        public async Task<IEnumerable<NewsDto>> GetTopRatedNews()
        {
            var news = await _mediator.Send(new GetTopRatedNewsQuery()) as IEnumerable<NewsDto>;
            return news ;
        }
        

        public async Task<NewsDto> GetNewsById(Guid id)
        {
            throw new NotImplementedException();

        }

        public async Task<NewsWithRssNameDto> GetNewsWithRssSourseNameById(Guid id)
        {
            throw new NotImplementedException();

        }

        public async Task Aggregate()
        {
            var rssSourses = await _mediator.Send(new GetAllRssSoursesQuery());
            
            var news = new ConcurrentBag<NewsDto>();
            var currentNewsUrls = await _mediator.Send(new GetAllExistingNewsUrlsQuery());

            Parallel.ForEach(rssSourses, (rssSourse) =>
            {
                using (var reader = XmlReader.Create(rssSourse.Url))
                {
                    var feed = SyndicationFeed.Load(reader);

                    reader.Close();
                    if (feed.Items.Any())
                    {
                        foreach (var syndicationItem in feed.Items
                            .Where(item => !currentNewsUrls.Any(url => url.Equals(item.Id))))
                        {
                            var newsDto = new NewsDto()
                            {
                                Id = Guid.NewGuid(),
                                RssSourseId = rssSourse.Id,
                                Url = syndicationItem.Id,
                                Article = syndicationItem.Title.Text,
                                Summary = syndicationItem.Summary.Text //clean from html(?)
                            };
                            news.Add(newsDto);
                        }
                    }

                }
            });
            //news contains data from rss

            //todo for each news get data from Parser
            
            //todo insert all that news to database

            // in db contains text of news without html
        }

        public async Task RateNews()
        {
            //process news without rates
            //todo process news for get text in next format:
            var newsText =
                "Апрельская зарплата, по данным Белстата, снова выросла. На этот раз +13,5 рублей за месяц. При этом зарплата минчан перевалила за 2 тысячи рублей в месяц, хотя в Могилеве и области насчитали в среднем всего 1118,4 рубля.Средняя начисленная зарплата в Беларуси в апреле составила 1398,2 рубля, сообщает Белстат. Это значит, что по сравнению с мартом она выросла на 13,5 рубля. После вычета налогов у среднестатистического белоруса на руках осталось 1202,45 рубля.Напомним, в марте этого года средняя заработная плата работников была 1384,7, в феврале — 1277,1 рубля.Топ зарплат в апреле выглядит так. Больше всех по традиции в апреле получили работники IT-сферы — 4684,2 рубля, за ними идут финансисты и страховщики (3505,2 рубля), работники грузового авиатранспорта (2956,3 рубля).Меньше всех получают работники сферы красоты и парикмахеры — 663,6 рубля до вычета налогов. За ними идут деятели сферы искусств и творческие работники (746,1 рубля). Библиотекари и музейные работники замыкают топ самых низких зарплат с показателем 751,9 рубля.При этом средняя зарплата минчан перевалила за 2 тысячи рублей в месяц и составила 2003,4 рубля. Неплохо. В минской области в апреле получали в среднем 1409,5 рублям, а в аутсайдерах, по традиции, жители Могилева и области (1118,4 рубля).";


            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "http://api.ispras.ru/texterra/v1/nlp?targetType=lemma&apikey=15031bb039d704a3af5d07194f427aa3bf297058")
                {
                    Content = new StringContent("[{\"text\":\"" + newsText + "\"}]",

                        Encoding.UTF8,
                        "application/json")
                };
                var response = await httpClient.SendAsync(request);

                var responseString = await response.Content.ReadAsStringAsync();
            }

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
