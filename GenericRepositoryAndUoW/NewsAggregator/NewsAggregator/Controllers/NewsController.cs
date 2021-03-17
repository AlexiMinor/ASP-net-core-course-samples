using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsAggregator.Core.DataTransferObjects;
using NewsAggregator.Core.Services.Interfaces;
using NewsAggregator.DAL.Core;
using NewsAggregator.DAL.Core.Entities;
using NewsAggregator.Models.ViewModels;

namespace NewsAggregator.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        // GET: News

        public async Task<IActionResult> Index(Guid? sourseId)
        {
            if (sourseId == null)
            {
                return NotFound();
            }
            var model = (await _newsService.GetNewsBySourseId(sourseId))
                .ToList();

            return View(model);
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewsDto sourse)
        {
            if (ModelState.IsValid)
            {
                sourse.Id = Guid.NewGuid();
                await _newsService.AddNews(sourse);
                return RedirectToAction(nameof(Index));
            }
            return View(sourse);
        }
    }
}
