using System;
using System.Collections.Generic;

namespace NewsAggregator.DAL.Core.Entities
{
    public class RssSourse : IBaseEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Url { get; set; }

        public virtual ICollection<News> NewsCollection { get; set; }
    }
}