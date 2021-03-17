using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsAggregator.DAL.Core;
using NewsAggregator.DAL.Core.Entities;
using NewsAggregator.DAL.Repositories.Interfaces;

namespace NewsAggregator.DAL.Repositories.Implementation
{
    public class RssSourseRepository : IRepository<RssSourse>
    {
        private readonly NewsAggregatorContext _context;

        public RssSourseRepository(NewsAggregatorContext context)
        {
            _context = context;
        }

        //CRUD - CREATE READ UPDATE DELETE
        public IQueryable<RssSourse> FindBy(Expression<Func<RssSourse, bool>> predicate, params Expression<Func<RssSourse, object>>[] includes)
        {
            throw new NotImplementedException();
        }

        public async Task Add(RssSourse news)
        {
            await _context.RssSources.AddAsync(news);
            await _context.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<RssSourse> news)
        {
            throw new NotImplementedException();
        }

        public async Task<RssSourse> GetById(Guid id)
        {
            return await _context.RssSources.FirstOrDefaultAsync(news => news.Id.Equals(id));
        }

        public IQueryable<RssSourse> GetRssSourses()
        {
            return _context.RssSources;
        }

        public async Task Update(RssSourse news)
        {
            _context.RssSources.Update(news);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(Guid id)
        {
            var news = await GetById(id);
            _context.RssSources.Remove(news);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRange(IEnumerable<RssSourse> news)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}