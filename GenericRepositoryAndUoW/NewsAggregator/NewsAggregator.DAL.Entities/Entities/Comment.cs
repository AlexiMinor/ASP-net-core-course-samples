using System;

namespace NewsAggregator.DAL.Core.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Text { get; set; }

        public DateTime Created { get; set; }

        public Guid NewsId { get; set; } //FK
        public virtual News News { get; set; }

        public Guid UserId { get; set; } //FK
        public virtual User User { get; set; }
    }
}