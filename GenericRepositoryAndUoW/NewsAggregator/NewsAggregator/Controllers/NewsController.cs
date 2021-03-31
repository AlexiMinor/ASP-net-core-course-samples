using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewsAggregator.Core.DataTransferObjects;
using NewsAggregator.Core.Services.Interfaces;
using NewsAggregator.Models;
using NewsAggregator.Models.ViewModels.News;

namespace NewsAggregator.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;
        private readonly IRssSourseService _rssSourse;
        public NewsController(INewsService newsService, IRssSourseService rssSourse)
        {
            _newsService = newsService;
            _rssSourse = rssSourse;
        }

        // GET: News

        public async Task<IActionResult> Index(Guid? sourseId, int page = 1)
        {
            //if (sourseId == null)
            //{
            //    return NotFound();
            //}
            var news = (await _newsService.GetNewsBySourseId(sourseId))
                .ToList();

            var pageSize = 500;

            var newsPerPages = news.Skip((page - 1) * pageSize).Take(pageSize);

            var pageInfo = new PageInfo()
            {
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = news.Count
            };


            return View(new NewsListWithPaginationInfo()
            {
                News = newsPerPages,
                PageInfo = pageInfo
            });
        }

        // GET: News/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sourse = await _newsService.GetNewsWithRssSourseNameById(id.Value);

            if (sourse == null)
            {
                return NotFound();
            }

            var viewModel = new NewsWithRssNameDto()
            {
                Id = sourse.Id,
                Article = sourse.Article,
                Body = sourse.Body,
                Body2 = sourse.Body2,
                Url = sourse.Url,
                RssSourseId = sourse.RssSourseId,
                RssSourseName = sourse.RssSourseName // Null reference exception -> RssSourse is null
            };

            return View(sourse);
        }

        // GET: News/Create
        public async Task<IActionResult> Create()
        {
            
            var model = new CreateNewsViewModel()
            {
                Sources = new SelectList(await _rssSourse.GetAllRssSources(), 
                    "Id", //field of element with value
                    "Name") //field of element with text
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateNewsViewModel sourse)
        {
            if (ModelState.IsValid)
            {
                sourse.Id = Guid.NewGuid();
               
                //await _newsService.AddNews(sourse.);
                return RedirectToAction(nameof(Index));
            }
            return View(sourse);
        }
    }
}
