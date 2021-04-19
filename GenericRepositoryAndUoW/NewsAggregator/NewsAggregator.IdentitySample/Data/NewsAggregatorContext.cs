using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NewsAggregator.IdentitySample.Data
{
    public class NewsAggregatorContext: IdentityDbContext<User, Role, Guid>
    {
        public DbSet<Comment> Comments { get; set; }

        public NewsAggregatorContext(DbContextOptions<NewsAggregatorContext> options) 
            : base(options)
        {
        }
    }
}
