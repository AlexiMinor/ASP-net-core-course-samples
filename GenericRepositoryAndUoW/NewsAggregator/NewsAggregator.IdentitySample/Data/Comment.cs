using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsAggregator.IdentitySample.Data
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Text { get; set; }

        public DateTime Created { get; set; }

        public Guid UserId { get; set; } //FK
        public virtual User User { get; set; }
    }
}
