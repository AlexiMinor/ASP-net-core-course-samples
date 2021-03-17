using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsAggregator.DAL.Core;
using NewsAggregator.DAL.Core.Entities;
using NewsAggregator.DAL.Repositories.Interfaces;

namespace NewsAggregator.DAL.Repositories.Implementation
{
    public class NewsRepository : Repository<News>
    {
        public NewsRepository(NewsAggregatorContext context, DbSet<News> table) 
            : base(context, table)
        {
        }
    }
}